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

    $("#test").on("click",()=>{
      $(".UserSection_options").toggle();
      $(".UserSection_options").removeClass("hidden")
    });

      const optionHeader = $(".option_header");
      $(optionHeader).siblings().hide();

      $(optionHeader).on("click",()=>{
          $(event.currentTarget).siblings().slideToggle();
      })

  });
  