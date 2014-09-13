function OnCreateCommitteeLoaded() {
    ko.applyBindings(new Committee());
}
var Committee = function () {
    var self = this;

    self.CommitteeName = ko.observable();
    self.Description = ko.observable();
    self.ChairPersons = ko.observableArray([new Adult()]);

    self.addChair = function () { self.ChairPersons.push(new Adult()) }
    self.removeChair = function () { self.ChairPersons.pop() }
    self.create = function () {

        var data = {};
        data.CommitteeName = self.CommitteeName();
        data.Description = self.Description();
        data.ChairPersons = $.map(self.ChairPersons(), function (chair) {
            var c = {
                Name: { First: chair.name().first(), Last: chair.name().last() },
                Phone: chair.Phone(),
                Email: chair.Email()
            }
            return c;
        });

        var dataString = JSON.stringify({ "data": data });
        var pathArray = window.location.href.split('/');
        var protocol = pathArray[0];
        var host = pathArray[2];
        var url = protocol + '//' + host;
        $.ajax({
            type: 'POST',
            url: url + '//committee//create.aspx//create',
            data: dataString,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: OnCreateSuccess,
            error: OnGetTeachersByGradeFailure
        });
    }
};

function OnCreateSuccess(msg) {
    alert("Created");
}
