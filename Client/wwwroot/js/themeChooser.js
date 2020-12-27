window.themeChooser = {
    setTheme: function (themeName){
        // built the new css link
        let newLink = document.createElement("link");
        newLink.setAttribute("id", "app-css");
        newLink.setAttribute("rel", "stylesheet");
        newLink.setAttribute("type", "text/css");
        newLink.setAttribute("href", `css/${themeName}.css`);

        // remove and replace the theme
        let head = document.getElementsByTagName("head")[0];
        head.querySelector("#app-css").remove();
        head.appendChild(newLink);
    }
}