async function cargarMenuCategories() {
    document.addEventListener('click', function (event) {
        const isClickInsideMenu = event.target.closest('.menu-item');
        if (!isClickInsideMenu) {
            const submenus = document.querySelectorAll('.submenu');
            submenus.forEach(submenu => {
                submenu.style.display = 'none';
            });
        }
    });

    const response = await fetch('/api/category/GetCategories');
    if (!response.ok) {
        return;
    }

    const listOfCategories = await response.json();
    mostrarMenuCategories(listOfCategories);
}

function mostrarMenuCategories(listOfCategories) {
    console.log("Cargando Categorias...");
    const subMenu = document.getElementById('subMenuCategorie');

    subMenu.innerHTML = '';

    listOfCategories.forEach(category => {
        const li = document.createElement('li');
        const a = document.createElement('a');

        a.href = '#';
        a.textContent = category.name;
        li.appendChild(a);
        subMenu.appendChild(li);
    });
}

function toggleSubMenu(event) {
    event.preventDefault();
    const subMenu = document.getElementById('subMenuCategorie');
    subMenu.style.display = subMenu.style.display === 'none' ? 'block' : 'none';
}

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
    cargarMenuCategories();
});
