function loadHead() {
    fetch('/Partials/Header/head.html')
    .then(response => response.text())
    .then(data => {
        document.head.insertAdjacentHTML('beforeend', data);
    });
}

function loadHeader() {
    fetch('/Partials/Header/header.html')
    .then(response => response.text())
    .then(data => {
        document.getElementById('header').innerHTML = data;
        setActiveLink();
    });
}

function setActiveLink() {
    const currentPage = window.location.pathname;
    
    const menuLinks = {
        '/paginaPrincipal.html': 'pagina-principal',
        '/Views/Inventario/catalogo.html': 'catalogo',
        '/categorias.html': 'categorias',
        '/misPedidos.html': 'mis-pedidos',
        '/quienesSomos.html': 'quienes-somos',
        '/contactanos.html': 'contactanos'
    };
    console.log("Estamos en  " + currentPage);

    const activeLinkId = menuLinks[currentPage];
    if (activeLinkId) {
        const activeLink = document.getElementById(activeLinkId);
        if (activeLink) {
            activeLink.classList.add('active');
        }
    }
}

document.addEventListener('DOMContentLoaded', () => {
    loadHead();
    loadHeader();
});
