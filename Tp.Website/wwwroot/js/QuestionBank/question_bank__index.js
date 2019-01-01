QUESTION_BANK__INDEX = {
    init: function () {
        const app = QUESTION_BANK__INDEX;
        $("[data-card-type=category-summary] .h2").css("cursor", "pointer");
        $(document).on("click", "[data-card-type=category-summary] .h2", app.showQuestions);
    },
    showQuestions: function (event) {
        const $card = $(event.target).closest("[data-card-type]");
        const categoryId = $card.data("category-id");
        const controller = "QuestionBank";
        const action = "ListByCategory";
        window.location.href = `/${controller}/${action}?categoryId=${categoryId}`;
    }
};
$(document).ready(QUESTION_BANK__INDEX.init());