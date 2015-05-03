/// <reference path ="~/Scripts/jquery-2.1.1.js" />
/// <reference path ="~/Scripts/jquery.validate.js" />
/// <reference path ="~/Scripts/jquery.validate.unobtrusive.js" />
/// <reference path ="~/Scripts/knockout-3.1.0.js" />
/// <reference path ="~/Scripts/knockout-mapping.latest.js" />

ko.bindingHandlers.date = {
    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var value = valueAccessor();
        var allBindings = allBindingsAccessor();
        var valueUnwrapped = ko.utils.unwrapObservable(value);

        var pattern = allBindings.format || 'DD/MM/YYYY';

        var output = "-";
        if (valueUnwrapped !== null && valueUnwrapped !== undefined && valueUnwrapped.length > 0) {
            output = moment(valueUnwrapped).format(pattern);
        }

        if ($(element).is("input") === true) {
            $(element).val(output);
        } else {
            $(element).text(output);
        }
    }
};

sectionVM = function (data) {
    var self = this;
    var completeVM = data;
    var bookVM = data.Book;
    var foodVM = data.Food;
    completeVM.MoreGuests = ko.observableArray();

    var secondOptionSelected = ko.computed(function () {
        return completeVM.SelectedOption() == "2"
    })

    var thirdOptionSelected = ko.computed(function () {
        return completeVM.SelectedOption() == "3"
    })

    var Guest = function (guest) {
        var self = this;
        self.Name = ko.observable(guest ? guest.Name : '');
        self.State = ko.observable(guest ? guest.State : '');
        self.Street = ko.observable(guest ? guest.Street : '');
        self.City = ko.observable(guest ? guest.City : '');
        self.Zip = ko.observable(guest ? guest.Zip : '');
    }

    completeVM.removeGuest = function (guest) {
        completeVM.MoreGuests.remove(guest);
    }

    completeVM.addGuest = function () {
        completeVM.MoreGuests.push(new Guest());
        $("thisForm").data("validator", null);
        $.validator.unobtrusive.parse($("thisForm"));
    }

    completeVM.EligibleRadioHelper = ko.computed({
        read: function () {
            return completeVM.Eligible().toString();
        },
        write: function (value) {
            completeVM.Eligible(value === 'true');
        },
        owner: this
    });

    return {
        completeVM: completeVM,
        selectOptionVM: bookVM,
        foodVM: foodVM,
        secondOptionSelected: secondOptionSelected,
        thirdOptionSelected: thirdOptionSelected
     }
}

$(document).ready(function () {

    var viewModel = new sectionVM(subViewModel);
    ko.applyBindings(viewModel);

    $.validator.unobtrusive.parse("#thisForm");
    $("#thisForm").data("validator").settings.submitHandler = viewModel.save;

    viewModel.save = function () {
        var optionModel = ko.mapping.toJS(viewModel.completeVM);
        ko.utils.postJson("/SelectOption/Create", optionModel);
    }

});