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

    return `<div class="product">
                <img src="https://assets.digicorp.com.bo/product_images/webp/79005-image-1-1729546800325.webp">
                
                <p>${obj.name}</p>
                <p class="price">${obj.price}<span>Bs</span></p>
                <p class="stock">stock: 10</p>
            </div>`
}