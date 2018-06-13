(function () {
    
    event = function (event) {        
        if (event.animationName == 'nodeInserted') {

            var scope = angular.element(event.target).scope();            
            if (scope && $(event.target).hasClass('umb-property')) {                
                if (scope.property && scope.property.config) {                       
                    $.get("backoffice/HidePreviewButton/HidePreviewButtonApi/IsAllow", { url: location.hash }, function (res) {                        
                        if (res != true) {
                            var previewButtons = $(".umb-tab-buttons div[label-key='buttons_showPage']");
                            previewButtons.each(function () {
                                $(this).remove();
                            });
                        }
                    })
                }
            }

        }
    }

    document.addEventListener('animationstart', event, false);
    document.addEventListener('MSAnimationStart', event, false);
    document.addEventListener('webkitAnimationStart', event, false);
})();