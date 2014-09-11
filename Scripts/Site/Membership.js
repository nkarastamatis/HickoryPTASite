
var membership = {
    teachersByGrade: null,
    membershipTypes: ["Single", "Family", "Corporate"]
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
    ko.applyBindings(new MembershipInfo());
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

var Adult = function() {
    var self = this;
}

var MembershipInfo = function () {
    var self = this;
    self.membershipTypes = ko.observableArray(membership.membershipTypes);
    self.membershipType = ko.observable();
    self.adults = ko.observableArray([new Adult()]);
    self.children = ko.observableArray([new Class()]);
    self.shouldShowRemove = ko.observable(false);

    self.addChild = function () { self.children.push(new Class()) };
    self.removeChild = function () { self.children.pop() };

    self.children.subscribe(function () {
        self.shouldShowRemove(self.children().length > 1);
    })

    self.membershipType.subscribe(function () {
        if (self.membershipType() == "Family")
            self.adults.push(new Adult());
        else if (self.adults().length > 1)
            self.adults.pop();
    })
    
}

