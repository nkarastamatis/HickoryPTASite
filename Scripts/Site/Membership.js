
var membership = {
    teachersByGrade: null
};

function OnMembershipLoaded() {
    var pathArray = window.location.href.split('/');
    var protocol = pathArray[0];
    var host = pathArray[2];
    var url = protocol + '//' + host;

    $.ajax({
        type: 'POST',
        url: url + '//membership//membership.aspx//GetTeachersByGrade',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: OnGetTeachersByGradeSuccess,
        error: OnGetTeachersByGradeFailure
    });

}

function OnGetTeachersByGradeSuccess(msg) {
    var i = 0;
    membership.teachersByGrade = JSON.parse(msg.d);
    ko.applyBindings(new Family());
}

function OnGetTeachersByGradeFailure(XMLHttpRequest, textStatus, errorThrown) {
    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
}

var Class = function () {
    var self = this;

    var grades = [];
    for (var key in membership.teachersByGrade)
        grades.push(key);


    self.grades = ko.observableArray(grades);
    self.selectedGrade = ko.observable();
    self.teachers = ko.observableArray();
    self.selectedGrade.subscribe(function () {
        var grade = self.selectedGrade.arguments[0];
        var names = [];        
        var teachers = membership.teachersByGrade[grade];
        teachers.forEach(function (teacher) {
            names.push(teacher.NameString);
        });
        self.teachers(names);
    })

};

var Family = function () {
    var self = this;
    self.children = ko.observableArray([new Class()]);

    self.addChild = function () { self.children.push(new Class()) };
}

