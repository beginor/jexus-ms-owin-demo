(function() {

    async function loadDemos() {
        const res = await fetch('api/demo', { method: 'GET' });
        const result = await res.json()
        var html = [];
        for (const msg of result) {
            html.push('<div>' + JSON.stringify(msg) + '</div>')
        }
        document.getElementById('messages').innerHTML = html.join('<br />');
    }

    window.addEventListener('load', async () => {
        await loadDemos();
    });

    document.getElementById('addBtn').addEventListener('click', async () => {
        const message = document.getElementById('message').value;
        const res = await fetch(
            'api/demo',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ message })
            }
        );
        if (res.ok) {
            var json = await res.text();
            // alert(json)
            loadDemos();
        }
        else {
            alert('Request Error!');
            console.error(res.status);
        }
    });

})();
