function sendSelectedValue() {
    var selectElement = document.getElementById("mySelect");
    var selectedValue = selectElement.value;

    fetch(`/Catalog/GetSelectedValue?value=${encodeURIComponent(selectedValue)}`, {
        method: 'GET'
    })
        .then(response => response.json())
        .then(data => {
            console.log(data);
            // Здесь можно обновить DOM в соответствии с данными, возвращенными с сервера
        })
        .catch(error => console.error('Error:', error));
}