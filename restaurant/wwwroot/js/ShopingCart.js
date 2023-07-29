$(document).ready(()=>{
    $(".productCard_buyButton").on("click",(e)=>{
        e.preventDefault();
        getProductData(e);
        
    })
    
    let productList = getLStorage() != null ? getLStorage() : [] ;
    const getProductData = (e) =>{
        let product = {};
        product["name"] = $(e.currentTarget).siblings().text()
        product["price"] = $(e.currentTarget).parent().siblings().eq(1).children().text();
        product["img"] = $(e.currentTarget).parent().siblings().eq(0).children().attr("src");
        productList.push(product);
        const stringArray = JSON.stringify(productList)
        localStorage.setItem("shopingCart",stringArray)
        console.log(productList);
    }

    const addToLStorage = (array) =>{
        const stringArray = JSON.stringify(array)
        localStorage.setItem("shopingCart",stringArray);
    }

    function getLStorage () {
        const stringArray = localStorage.getItem("shopingCart")
        const shopingCart = JSON.parse(stringArray)
        return shopingCart
    }

    const createElement = (price,nameProduct,img) =>{

        var cartProduct = $("<div>").addClass("cart_product")
        var productImg = $("<img>").addClass("product_img").attr("src",img)
        var productDataHandler = $("<div>").addClass("product_dataHandler")
        var productName = $("<label>").addClass("product_name").text(nameProduct)
        var dataHandlerQuantity = $("<div>").addClass("dataHandler_quantity")
        var quantityLabel = $("<label>").addClass("quantity_label").text("Cantidad")
        var quantityCounter = $("<div>").addClass("quantity_counter")
        var quantityValue = $("<label>").text("1")

        quantityCounter.append(quantityValue);
        dataHandlerQuantity.append(quantityLabel);      
        dataHandlerQuantity.append(quantityCounter);      
        productDataHandler.append(productName);
        productDataHandler.append(dataHandlerQuantity);
    
        var productDataHandler2 = $("<div>").addClass("product_dataHandler");
        var dataHandlerPrice = $("<label>").addClass("dataHandler_price").text(price);
        var dataHandlerQuantityOptions = $("<div>").addClass("dataHandler_quantityOptions");
    
        var quantityOptionsAdd = $("<div>").addClass("quantityOptions_add").text("+");
        var quantityOptionsSustract = $("<div>").addClass("quantityOptions_sustract").text("-");
        var quantityOptionsDelete = $("<div>").addClass("quantityOptions_delete").text("0");
    
        dataHandlerQuantityOptions.append(quantityOptionsAdd);
        dataHandlerQuantityOptions.append(quantityOptionsSustract);
        dataHandlerQuantityOptions.append(quantityOptionsDelete);
        productDataHandler2.append(dataHandlerPrice);
        productDataHandler2.append(dataHandlerQuantityOptions);
        cartProduct.append(productImg);
        cartProduct.append(productDataHandler);
        cartProduct.append(productDataHandler2);
    
        $(".shoppingCart_cart").append(cartProduct);
    }

    if($(".shoppingCart_cart") != null){
        let cart = getLStorage()
        cart.forEach(element => {
            createElement(element.price,element.name,element.img)
        });
        console.log("si existe")
    }else{
        console.log("no existe")
    }
    

});