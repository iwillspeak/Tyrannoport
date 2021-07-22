const darkModePlaceholder = document.getElementById("dark-mode-placeholder");
const prefersDarkMode = window.matchMedia("(prefers-color-scheme: dark)");

const sunIcon = `<svg class="octicon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" width="16" height="16"><path fill-rule="evenodd" d="M8 10.5a2.5 2.5 0 100-5 2.5 2.5 0 000 5zM8 12a4 4 0 100-8 4 4 0 000 8zM8 0a.75.75 0 01.75.75v1.5a.75.75 0 01-1.5 0V.75A.75.75 0 018 0zm0 13a.75.75 0 01.75.75v1.5a.75.75 0 01-1.5 0v-1.5A.75.75 0 018 13zM2.343 2.343a.75.75 0 011.061 0l1.06 1.061a.75.75 0 01-1.06 1.06l-1.06-1.06a.75.75 0 010-1.06zm9.193 9.193a.75.75 0 011.06 0l1.061 1.06a.75.75 0 01-1.06 1.061l-1.061-1.06a.75.75 0 010-1.061zM16 8a.75.75 0 01-.75.75h-1.5a.75.75 0 010-1.5h1.5A.75.75 0 0116 8zM3 8a.75.75 0 01-.75.75H.75a.75.75 0 010-1.5h1.5A.75.75 0 013 8zm10.657-5.657a.75.75 0 010 1.061l-1.061 1.06a.75.75 0 11-1.06-1.06l1.06-1.06a.75.75 0 011.06 0zm-9.193 9.193a.75.75 0 010 1.06l-1.06 1.061a.75.75 0 11-1.061-1.06l1.06-1.061a.75.75 0 011.061 0z"></path></svg>`;
const moonIcon = `<svg class="octicon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" width="16" height="16"><path fill-rule="evenodd" d="M9.598 1.591a.75.75 0 01.785-.175 7 7 0 11-8.967 8.967.75.75 0 01.961-.96 5.5 5.5 0 007.046-7.046.75.75 0 01.175-.786zm1.616 1.945a7 7 0 01-7.678 7.678 5.5 5.5 0 107.678-7.678z"></path></svg>`;

const setIconFromMode = (button, mode) => {
    if (mode === "auto") {
        mode = prefersDarkMode.matches ? "dark" : "light";
    }

    button.innerHTML = (mode === "light") ?
        moonIcon : sunIcon;
};

const toggleMode = () => {
    const dataSet = document.documentElement.dataset;
    const currentMode = dataSet.colorMode;

    if (currentMode === "auto") {
        if (prefersDarkMode.matches) {
            dataSet.colorMode = "light";
        } else {
            dataSet.colorMode = "dark";
        }
        localStorage.setItem("stashed-theme", dataSet.colorMode);
    } else {
        dataSet.colorMode = "auto";
        localStorage.removeItem("stashed-theme");
    }

    return dataSet.colorMode;
}

const stashedTheme = localStorage.getItem("stashed-theme");
if (stashedTheme) {
    document.documentElement.dataset.colorMode = stashedTheme;
}

// Create a button and add it to the DOM to allow toggling dark mode.

const darkModeButton = document.createElement("a");
darkModeButton.classList.add("Header-link")
darkModeButton.type = "button"
darkModeButton.addEventListener("click", () => {
    setIconFromMode(darkModeButton, toggleMode());
});
setIconFromMode(darkModeButton, document.documentElement.dataset.colorMode);

darkModePlaceholder.appendChild(darkModeButton);