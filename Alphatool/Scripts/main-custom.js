    jQuery(document).ready(function () {
        alert('ok');
        $('.youtube-media').magnificPopup({
            type: 'iframe',
            mainClass: 'mfpc-fade',
            removalDelay: 160,
            preloader: true,
            fixedContentPos: false
        });
    });
