(function () {
    const urlParams = new URLSearchParams(window.location.search);
    let articleId = urlParams.get("id");
    if (articleId.trim() === "") {
        window.location.href = "/paginaPrincipal.html";
    }
    loadDetail(articleId);
})();

async function loadDetail(articleId) {
    const response = await fetch(`/api/article/${articleId}`)
    const article = await response.json();
    document.querySelector(".product-title").innerHTML = `<h2 class="main">${article.name}</h2>`;
    const detailArticle = document.getElementById("detailArticle");
    detailArticle.innerHTML = getArticleInfo(article);
}

function getArticleInfo(article) {
    const imageUrl = !article.imagenId || article.imagenId === 0 ? '/Assets/img/icon-article.png' : `/api/image/${article.imagenId}`;
    return `
    <div>
        <section class="product-image">
            <img src="${imageUrl}">
        </section>
    </div>
    <div class="product-info">
        <div class="info-section">
            <p class="price">${article.price} Bs</p>
            <h2>Detalles del Producto</h2>
            <ul>
                <li><strong>Marca:</strong> ${article.brand.name}</li>
                <li>
                    <p>
                        <strong>Descricion del producto:</strong>
                    </p>
                    ${article.description}
                </li>
            </ul>
            </div>
                <div class="info-section">
                    <h2>Stock Disponible</h2>
                </div>
                <div class="stock-info">
                    <h2>Disponibilidad en Oficinas</h2>
                    <table>
                        <thead>
                            <tr>
                                <th>Ubicación</th>
                                <th>Stock Actual</th>
                                <th>Pedidos</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>SC | Oficina Central</td>
                                <td>50+</td>
                                <td><input style="width:40px" type="number" min="0" value="0"></td>
                            </tr>
                        </tbody>
                    </table>
            </div>
    </div>
    `
}