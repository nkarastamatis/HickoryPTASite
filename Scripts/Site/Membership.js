
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

var Name = function () {
    var self = this;

    self.first = ko.observable();
    self.last = ko.observable();
}

var Student = function () {
    var self = this;

    var grades = [];
    for (var key in membership.teachersByGrade)
        grades.push(key);

    self.name = ko.observable(new Name());
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
    self.name = ko.observable(new Name());
    self.Phone = ko.observable();
    self.Email = ko.observable();

    self.Phone.subscribe(function () {
        var formattedPhone = formatPhoneNumber(self.Phone());
        self.Phone(formattedPhone);
    });
    //self.first = ko.observable();
    //self.last = ko.observable();
}

var MembershipInfo = function () {
    var self = this;
    self.membershipTypes = ko.observableArray(membership.membershipTypes);
    self.membershipType = ko.observable();
    self.adults = ko.observableArray([new Adult()]);
    self.children = ko.observableArray([new Student()]);

    self.streetAddress = ko.observable();
    self.city = ko.observable();
    self.zip = ko.observable();

    self.shouldShowRemove = ko.observable(false);

    self.addChild = function () { self.children.push(new Student()) };
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

    self.submit = function () {
        var data = {};
        data.children = $.map(self.children(), function(child) {
            var c = {
                name: {fist: child.name().first(), last: child.name().last()},
                grade: child.selectedGrade()
            }
            return c;
            
        });
        data.adults = $.map(self.adults(), function (adult) {
            var a = {
                name: { first: adult.name().first(), last: adult.name().last() }
            }
            return a;
        });
        data.address = {
            streetAddress: self.streetAddress(),
            city: self.city(),
            zip: self.zip()
        };
        var dataString = JSON.stringify({ "data": data });
        var pathArray = window.location.href.split('/');
        var protocol = pathArray[0];
        var host = pathArray[2];
        var url = protocol + '//' + host;

        $.ajax({
            type: 'POST',
            url: url + '//membership//membership.aspx//submit',
            data: dataString,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: OnSubmitSuccess,
            error: OnGetTeachersByGradeFailure
        });

    }
    
}
function OnSubmitSuccess(msg) {
    alert("Sent");
}

