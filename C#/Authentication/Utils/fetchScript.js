fetch('http://localhost:5000/login/', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json'
    },
    credentials: 'include' // Inclui cookies na requisição
})
.then(response => response.json())
.then(data => alert(data))
.catch(error => console.error('Erro:', error));

async function logoff() {
    fetch('http://localhost:5000/logout/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        credentials: 'include'
    }).then(response => response.json())
    .then(data => alert(data))
    .catch(error => console.error('Erro: ', error))
}