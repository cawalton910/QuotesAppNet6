"using strict";
(function _homeIndexMain() {
    console.log("Home Index");
    _clearErrorMessages();
    const createQuoteModalDOM = document.querySelector("#createQuoteModal");
    const createQuoteModal = new bootstrap.Modal(createQuoteModalDOM);
    const createQuoteButton = document.querySelector("#btnCreateQuote");
    createQuoteButton.addEventListener("click", event => {
        createQuoteModal.show();
    })
    const createQuoteForm = document.querySelector("#createQuoteForm");
    createQuoteForm.addEventListener("submit", async (event) => {
        event.preventDefault();
        _clearErrorMessages();
        console.log("Submit");
        await _submitWithAjax(createQuoteForm);
    });
    async function _submitWithAjax(createQuoteForm) {
        const url = createQuoteForm.getAttribute('action') + "ajax";
        console.log(url);
        const method = createQuoteForm.getAttribute('method');
        const formData = new FormData(createQuoteForm);
        const response = await fetch(url, {
            method: method, body: formData
        });
        if (response.ok == false) {
            throw new Error("There was an HTTP error!");
        }
        const result = await response.json();
        if (result === "fail") {
            return;
        }
        console.log(result);
        createQuoteModal.hide();
        _updateQuotesTable(result.quoteId)
        $('#messageArea').html("A new quote was added!");
        $('#alertArea').show();
        // After 500ms, fade out over 500ms
        setInterval(() => {
            $('#alertArea').fadeOut(500);
        }, 500);
    }
    function _clearErrorMessages() {
        let spans = document.querySelectorAll('span[data-valmsg-for]');
        spans.forEach(s => {
            s.textContent = "";
        });
    }

})();
async function _updateQuotesTable(quoteId) {
    const url = `/quote/quoterow/${quoteId}`;
    const response = await fetch(url, {
        method: "get"
    });
    var result = await response.text();
    console.log(result);
    $("#tbody-quotes").append(result);
}