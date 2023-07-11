$(document).ready(()=>{
    const dropzoneContainer = document.querySelector(".dropzoneContainer");

    dropzoneContainer.addEventListener("dragover", function (e) {
    e.preventDefault();
    e.stopPropagation();
    $(dropzoneContainer).addClass("dragover");
    });

    dropzoneContainer.addEventListener("dragleave", function (e) {
    e.preventDefault();
    e.stopPropagation();
    $(dropzoneContainer).removeClass("dragover");
    });

    dropzoneContainer.addEventListener("drop", function (e) {
        e.preventDefault();
        e.stopPropagation();
        $(dropzoneContainer).removeClass("dragover");

        let files = e.dataTransfer.files;
        const fileInput = document.getElementById("fileInput");
        fileInput.files = files;
        if(fileInput.files){
           const image = document.getElementById("fileImg")
           const imageMessage = document.getElementById("fileMessageContainer")
           image.src = URL.createObjectURL(files[0]);
           
           imageMessage.style.display = "none"
           image.style.display = "block"
           
           console.log(files);
        }
    });
})