var createCommittee = {
    availableMembers: null,
};

function OnCreateCommitteeLoaded() {
    $('phone').keyup(formatPhoneNumber);    

    var pathArray = window.location.href.split('/');
    var protocol = pathArray[0];
    var host = pathArray[2];
    var url = protocol + '//' + host;
    $.ajax({
        type: 'POST',
        url: url + '//committee//create.aspx//GetAvailableChairs',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: OnGetAvailableChairsSuccess,
        error: OnGetTeachersByGradeFailure
    });
}

function OnGetAvailableChairsSuccess(msg) {
    var i = 0;
    createCommittee.availableMembers = JSON.parse(msg.d);
    ko.applyBindings(new Committee());
}

var CommitteeChair = function () {
    var self = this;

    self.availableMembers = ko.observableArray(createCommittee.availableMembers);
    self.selectedMember = ko.observable();
}

var Committee = function () {
    var self = this;

    self.CommitteeName = ko.observable();
    self.Description = ko.observable();
    self.SelectedChairs = ko.observableArray([new CommitteeChair()]);

    self.addChair = function () { self.SelectedChairs.push(new CommitteeChair()) }
    self.removeChair = function () { self.SelectedChairs.pop() }
    self.create = function () {

        var data = {};
        data.CommitteeName = self.CommitteeName();
        data.Description = self.Description();
        data.ChairPersons = $.map(self.SelectedChairs(), function (chair) {
            var c = {
                CommitteeName: data.CommitteeName,
                MemberId: chair.selectedMember().MemberId
                //Name: { First: chair.name().first(), Last: chair.name().last() },
                //Phone: chair.Phone(),
                //Email: chair.Email()
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
