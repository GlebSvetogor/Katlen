function sendSortSelectedValue() {
    var selectElement = document.getElementById("sortSelect");
    var selectedValue = selectElement.value;

    window.location.href = `/Catalog/GetSortSelectedValue?value=${encodeURIComponent(selectedValue)}`;
}

function sendOptionSelectedValue() {
    var selectElement = document.getElementById("optionSelect");
    var selectedValue = selectElement.value;

    window.location.href = `/Catalog/GetOptionSelectedValue?value=${encodeURIComponent(selectedValue)}`;
}

