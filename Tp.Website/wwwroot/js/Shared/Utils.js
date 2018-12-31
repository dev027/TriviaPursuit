var UTILS = {
    submitForm: function (
        submitButton,
        formWrapperId,
        controller,
        action,
        successMessage,
        successDelegate,
        successDelegateOptions,
        failMessage,
        failDelegate,
        failDelegateOptions) {
        const $submitButton = $(submitButton);
        const $form = $(submitButton).closest("form");
        const $formWrapper = $(`#${formWrapperId}`);

        const $actionButtonGroup = $submitButton.closest(".action-button-group");
        if ($actionButtonGroup.length > 0) {
            $actionButtonGroup.addClass("action_button_group--is-saving");
        }

        const postData = $form.serialize();

        $.ajax({
            url: `/${controller}/${action}`,
            data: postData,
            method: "POST",
            success: function (result) {
                $formWrapper.empty().replaceWith(result);
                $(".tooltip").hide();
                if (successMessage !== undefined) {
                    window.toastr.success(successMessage);
                }
                if (successDelegate !== undefined) {
                    successDelegate(successDelegateOptions);
                }
            },
            error: function (result) {
                if ($actionButtonGroup.length > 0) {
                    $actionButtonGroup.removeClass(".action-button-group--is-saving");
                }

                if (failMessage !== undefined) {
                    window.toastr.error(failMessage);
                }
                if (failDelegate !== undefined) {
                    failDelegate(failDelegateOptions);
                }
                UTILS.ajaxError(result, formWrapperId);
            }
        });
    },
    ajaxError: function (response, containerId) {
        switch (response.status) {
            case 400:
                if (containerId === undefined) {
                    UTILS.messageBoxOneOption({
                        title: UTILS.ajaxErrorTitle(response.status),
                        message: response.statusText
                    });
                } else {
                    UTILS.displayModelStateErrors(containerId, response.responseJSON);
                }
                break;
            default:
                UTILS.messageBoxOneOption({
                    title: UTILS.ajaxErrorTitle(response.status),
                    message: response.statusText
                });
        }
    },
    ajaxErrorTitle: function (httpStatusCode) {
        switch (httpStatusCode) {
            case 400:
                return UTILS.icon("warning", "warning") + "Validation Failure";
            case 401:
                return UTILS.icon("user-secret", "danger") + "Unauthorised";
            case 403:
                return UTILS.icon("times-circle", "danger") + "Forbidden";
            case 404:
                return UTILS.icon("times-circle", "danger") + "404 Not Found";
            case 409:
                return "409 Conflict";
            case 410:
                return UTILS.icon("times-circle", "info") + "410 Gone";
            case 418:
                return UTILS.icon("coffee") + "418 I'm a teapot";
            case 500:
                return UTILS.icon("frown-o", "danger") + "Internal Server Error";
            default:
                return "Error " + httpStatusCode;
        }
    },
    icon: function (fontAwesomeIcon, context) {
        var icon = "<i class='icon-offset fa fa-" + fontAwesomeIcon;
        if (context !== undefined) {
            icon += " text-" + context;
        }
        return icon + "'></i>";
    },
    displayModelStateErrors: function (containerId, errors) {
        var $container = $("#" + containerId);
        $container.find(".invalid-feedback").removeClass("d-block");

        var propNames = Object.keys(errors);
        $.each(propNames,
            function (i, propName) {
                var propErrors = errors[propName];
                var message = "";
                if (propErrors.length > 1) {
                    $.each(propErrors,
                        function (j, propError) {
                            message += `<li>${propError}</li>`;
                        });
                    message = `<ul>${message}</ul>`;
                } else {
                    message = propErrors[0];
                }
                $container.find(`[data-val-msg-for=${propName}]`)
                    .addClass("d-block")
                    .html(message);
            });

    },
    messageBoxOneOption: function (params) {
        alert(params.title + "\n\n" + params.message);
    }
}
