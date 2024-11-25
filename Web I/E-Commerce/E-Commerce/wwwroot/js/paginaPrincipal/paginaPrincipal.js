(function () {
    loadPage();
})();

async function loadPage() {
    const response = await fetch('/api/article/GetArticles');
    if (!response.ok) {
        return;
    }

    const listOfArticles = await response.json();
    mostrarAllArticles(listOfArticles, 'Todos los Productos');
}

function mostrarAllArticles(listOfArticles, title) {
    const allArticlesHtml = document.getElementById("allArticles");

    if (listOfArticles.length === 0) {
        allArticlesHtml.innerHTML =
            `<span>
                En la aplicacion no existe productos registrados.
            </span>`;
        return;
    }

    let html = `
    <h1>${title}</h1>
    <div class="carousel-container">
        <button class="prev" onclick="moveCarousel(-1)">&#10094;</button>
        
        <div class="carousel">`;
    for (let i in listOfArticles) {
        const obj = listOfArticles[i];
        html += getArticleHtml(obj);
    }
    html +=`
        </div>

        <button class="next" onclick="moveCarousel(1)">&#10095;</button>
    </div>`
    allArticlesHtml.innerHTML = html;
}
function getArticleHtml(obj) {
    console.log(obj);
    const imageUrl = !obj.imagenId || obj.imagenId === 0 ? 'Assets/img/icon-article.png' : `api/image/${obj.imagenId}`;
    return `<div class="product" onClick="viewArticleDetail('${obj.id}')">
                <img src="${imageUrl}">
                <p>${obj.name}</p>
                <p class="price">${obj.price}<span>Bs</span></p>
                <p class="stock">stock: 10</p>
                <a href="/Views/Inventario/producto.html?id=${obj.id}" class="btnAddCart">Agregar al carrito</a>
            </div>`
}

function viewArticleDetail(id) {
    const url = `/Views/Inventario/producto.html?id=${id}`;
    window.location.href = url;
}