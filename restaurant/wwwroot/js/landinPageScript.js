$(document).ready(function() {
    $("#categorySelect").val("");
    $('.CategoryHandler_categoryItem').click(function() {
        $(this).removeClass();
        $(this).addClass("CategoryHandler_categoryItem-active")
        var siblings = $(this).siblings();
        siblings.each(function() {
          $(this).removeClass();
          $(this).addClass('CategoryHandler_categoryItem')
        });

        
        let id = $(this).attr("id");
        let lastId = id.charAt(id.length - 1)
        $("#categorySelect").val(lastId);
        $(".ProductSectionHeader").submit();
        console.log($("#category.Select").val())

    });
  });
  