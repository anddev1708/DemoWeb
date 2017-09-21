$(function () {
    /*Date of Birth*/
    jQuery.validator.addMethod('validbirthdate', function (value, element, params) {
        var minDate = new Date(params["min"]);
        var maxDate = new Date(params["max"]);
        var dateValue = new Date(value);
        if (dateValue > minDate && dateValue < maxDate)
            return true;
        else
            return false;
    });

    jQuery.validator.unobtrusive.adapters.add('validbirthdate', ['min', 'max'], function (options) {
        var params = {
            min: options.params.min,
            max: options.params.max
        };

        options.rules['validbirthdate'] = params;
        if (options.message) {
            options.messages['validbirthdate'] = options.message;
        }
    });
    /*End*/
}(jQuery));