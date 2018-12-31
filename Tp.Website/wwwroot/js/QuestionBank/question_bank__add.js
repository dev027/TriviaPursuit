var QUESTION_BANK__ADD = {
    init: function () {
        const app = QUESTION_BANK__ADD;
        $(document).on("click", "[data-radio-id]", app.allNoneButtonPressed);
        $(document).on("click", "#js-add-question", app.addQuestionPressed);
    },
    allNoneButtonPressed: function (event) {
        ////var app = QUESTION_BANK__ADD;
        const button = event.target;
        const isPressedAfter = $(button).hasClass("btn-outline-secondary");
        const radioButton = $(button).data("radio-id");
        console.log("Radio-id = " + radioButton);
        if (isPressedAfter) {
            $("[data-radio-id]").removeClass("btn-success").addClass("btn-outline-secondary");
            $(button).removeClass("btn-outline-secondary").addClass("btn-success");
            $("#" + radioButton).click();
        } else {
            $(button).removeClass("btn-success").addClass("btn-outline-secondary");
            $("#js-all-none-none").click();
        }
    },
    addQuestionPressed: function (event) {
        ////var app = QUESTION_BANK__ADD;
        const submitButton = event.target;
        const wrapperId = "js-question";
        const controller = "QuestionBank";
        const action = "Add";
        UTILS.submitForm(submitButton, wrapperId, controller, action,
            "Question accepted");
    }
}
$(document).ready(QUESTION_BANK__ADD.init);
