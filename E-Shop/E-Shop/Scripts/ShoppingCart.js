var ShoppingCart = (function ($) {
    "use strict";

    var productsEl = ".products",
        productEl = '.product__item',
        productName = '.product__name',
        productPrice = '.product__price',
        productQuantity = '.product__quantity',
        cartItem = '.cart__item',
        total = '.total',
        modalNotification = '#OpenCart',
        cartTotal = '.cart__total';
    const emptyCartEl = ".empty-cart-btn";
    var productsInCart = [];

    var productFound = function (productId) {
        return productsInCart.find(function (item) {
            return item.id === productId;
        });
    }


    var setToLocalStorage = function () {
        localStorage.setItem("cart", JSON.stringify(productsInCart));
    }


    var cartCount = function () {
        var sum = 0;
        productsInCart.forEach(function (item) {
            sum += item.quantity;
        });

        document.querySelector("#cartCount").innerText = sum;
    }

    var updateFields = function (id) {
        var product = productFound(id);
        if (product === undefined) {
            product = { quantity: 0 };
        }
        const productTag = $(cartItem + "[data-id=" + id + "]");
        productTag.first().find(productQuantity).first().val(product.quantity);
        const price = parseInt(productTag.find(productPrice).first().text());
        productTag.first().find(total).first().text(product.quantity * price);
        const prices = $(total);
        var sum = 0;
        for (let i = 0; i < prices.length; i++) {
            sum += parseInt(prices[i].innerText);
        }
        $(cartTotal).first().text(sum);
    }

    var loadPage = function () {
        const cartTags = $(cartItem);
        var cartIds = [];
        for (let i = 0; i < cartTags.length; i++) {
            cartIds.push(cartTags[i].dataset.id);
            updateFields(cartTags[i].dataset.id);
        }
        var productIdsInCart = [];
        productsInCart.forEach(function (item) {
            productIdsInCart.push(item.id);
        });
        const difference = productIdsInCart.filter(x => cartIds.includes(x));
        difference.forEach(function (item) {
            $(cartItem + '[data-id=' + item + ']').toggleClass('d-none');
        });

    }

    var addToCart = function (id) {
        if (productsInCart.length === 0 || productFound(id) === undefined) {
            const product = $(productsEl).find(productEl + '[data-id=' + id + ']');
            const price = product.find(productPrice).first().text();
            const name = product.find(productName).first().text();
            productsInCart.push({ id: id, quantity: 1, name: name, price: price });
        } else {
            productFound(id).quantity++;
        }

        $(modalNotification).find('.modal-body').html('<h2><i class="fas fa-check text-success"></i> Товар добавлен в корзину</h2 >');
        $(modalNotification).modal('toggle');
    }

    var removeItem = function (id) {
        for (let i = 0; i < productsInCart.length; i++) {
            if (id === productsInCart[i].id) {
                productsInCart.splice(i, 1);
            }
        }
        $(cartItem + '[data-id=' + id + ']').first().hide();
    }

    const clear = function () {
        productsInCart.splice(0, productsInCart.length);
        setToLocalStorage();
    };

    var increment = function (id) {
        productFound(id).quantity++;
    }

    var decrement = function (id) {
        const product = productFound(id);
        if (product.quantity <= 1) product.quantity = 1;
        else product.quantity--;
    }

    var showCart = function () {
        const items = getItems();
        var res = "";
        if (items.length !== 0) {
            res += '<div class="table-responsive">  <table class="table"><tr><th>Название</th><th>Количество</th><th>Цена</th></tr>';
            for (let i = 0; i < productsInCart.length; i++) {
                res += '<tr><td>' + productsInCart[i].name + '</td><td>' + productsInCart[i].quantity + '</td><td>' + productsInCart[i].price + '</td></tr>';
            }
            res += '</table></div>';
        } else {
            res = "<h2>Корзина пуста</h2>";
        }

        document.getElementById('cartItems').innerHTML = res;
    };

    // Setting up listeners for click event on all products and Empty Cart button as well
    function setupListeners() {
        document.getElementById('OpenCartBtn').addEventListener('click', showCart);
        if (productsEl === null) return;
        $(productsEl).bind("click",
            function (event) {
                const el = event.target;
                const elId = el.dataset.id;
                if (el.classList.contains("add-to-cart")) {
                    addToCart(elId);
                } else {

                    const parentNode = el.closest(cartItem);
                    if (parentNode === null) {
                        return;
                    }

                    const prodId = parentNode.dataset.id;
                    if (el.classList.contains("remove-item")) {
                        removeItem(prodId);
                    }
                    if (el.classList.contains("cart__increment")) {
                        increment(prodId);
                    }
                    if (el.classList.contains("cart__decrement")) {
                        decrement(prodId);
                    }
                    updateFields(prodId);
                }
                setToLocalStorage();
                cartCount();
            });
    }

    var getItems = function () {
        return productsInCart;
    }

    var set = function () {
        const shoppingCart = JSON.parse(localStorage.getItem('cart'));
        if (shoppingCart === null) return;
        shoppingCart.forEach(function (item) {
            productsInCart.push({ id: item.id, quantity: item.quantity, price: item.price, name: item.name });
        });
    }

    const init = function () {
        set();
        cartCount();
        setupListeners();
        loadPage();
    };
    return {
        init: init,
        getItems: getItems,
        clear: clear,
        show: showCart
    };
})(jQuery);

ShoppingCart.init();