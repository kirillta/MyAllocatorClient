var getData = function() {
    const result = document.getElementById('Result');
    result.innerHTML = '';

    const xhr = new XMLHttpRequest();
    xhr.open('GET', 'http://localhost:61275/api/helloworld/', false);
    xhr.send();

    if (xhr.status !== 200) {
        console.log(xhr.status + ': ' + xhr.statusText);
    } else {
        result.innerHTML = xhr.responseText;
    }
};