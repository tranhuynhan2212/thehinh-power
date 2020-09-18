var select2Utils = function (idElement, selectedOptions, requestUrl) {
    var pageSize = 10;
    var optionListUrl = requestUrl;

    for (var i = 0; i < selectedOptions.length; i++) {
        var $newOption = $("<option selected='selected'></option>").val(selectedOptions[i].id).text(selectedOptions[i].text)
        $(idElement).append($newOption).trigger('change');
    }

    $(idElement).select2(
        {
            tags: true,
            ajax: {
                delay: 500,
                url: optionListUrl,
                dataType: 'json',
                data: function (params) {
                    params.page = params.page || 1;
                    return {
                        searchTerm: params.term,
                        pageSize: pageSize,
                        pageNumber: params.page
                    };
                },
                processResults: function (data, params) {
                    params.page = params.page || 1;
                    return {
                        results: data.Results,
                        pagination: {
                            more: (params.page * pageSize) < data.Total
                        }

                    };
                }
            },
            minimumInputLength: 0,
            placeholder: "",
            allowClear: true,
        });
};


var select2UtilsTopicStudent = function (idElement, selectedOptions, requestUrl, type, parentId, childrenId) {
    var pageSize = 10;
    var optionListUrl = requestUrl;

    for (var i = 0; i < selectedOptions.length; i++) {
        var $newOption = $("<option selected='selected'></option>").val(selectedOptions[i].id).text(selectedOptions[i].text)
        $(idElement).append($newOption).trigger('change');
    }

    $(idElement).select2(
        {
            ajax: {
                delay: 500,
                url: optionListUrl,
                dataType: 'json',
                data: function (params) {
                    params.page = params.page || 1;
                    return {
                        searchTerm: params.term,
                        pageSize: pageSize,
                        pageNumber: params.page,
                        type: type,
                        parentId: parentId,
                        childrenId: childrenId
                    };
                },
                processResults: function (data, params) {
                    params.page = params.page || 1;
                    return {
                        results: data.Results,
                        pagination: {
                            more: (params.page * pageSize) < data.Total
                        }

                    };
                }
            },
            minimumInputLength: 0,
            placeholder: "",
            allowClear: true,
        });
}
