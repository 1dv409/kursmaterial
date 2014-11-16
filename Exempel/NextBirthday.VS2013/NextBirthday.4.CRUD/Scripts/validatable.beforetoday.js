(function ($) {
	$.validator.addMethod("isDateLaterThanToday", function (value, element, params) {
		if (!/Invalid|NaN/.test(new Date(value))) {
			return new Date(value) < new Date();
		}
		return isNaN(value);
	}, '');

	$.validator.unobtrusive.adapters.add("beforetoday", {}, function (options) {
		options.rules['isDateLaterThanToday'] = true;
		options.messages['isDateLaterThanToday'] = options.message;
	});
}(jQuery));


