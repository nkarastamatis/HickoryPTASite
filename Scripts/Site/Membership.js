
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
    ko.applyBindings(new Class());
}

function OnGetTeachersByGradeFailure(XMLHttpRequest, textStatus, errorThrown) {
    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
}

var Class = function () {
    var self = this;

    var grades = [];
    for (var key in membership.teachersByGrade)
        grades.push(key.toString());


    self.grades = ko.observableArray(grades);
    self.selectedGrade = ko.observable();
    self.teachers = ko.observableArray();
    self.grades.subscribe( function() {
        self.teachers(self.selectedGrade.valueOf().value)
        })
};
