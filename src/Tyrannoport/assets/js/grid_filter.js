const initialiseFilter = element => {
    const filters = element.dataset.filterValues.split(",");
    const filterKey = element.dataset.filterKey;
    const targetSelector = element.dataset.filterTarget;
    const target = document.querySelector(targetSelector);

    if (target === null) {
        console.warn(`Could not find ${targetSelector}. Can't bind filter`);
        return;
    }

    const loadActiveFilter = () => {
        const query = new URLSearchParams(window.location.search);
        const stored = query.get(targetSelector);
        if (stored === null) {
            return [];
        }
        return stored.split(",").filter((filter, _i, _) => {
            return filters.includes(filter);
        });
    }

    const activeFilter = loadActiveFilter();

    const toggleFilter = (filter) => {
        const filterIdx = activeFilter.indexOf(filter);
        if (filterIdx > -1) {
            activeFilter.splice(filterIdx, 1);
            return false;
        }
        activeFilter.unshift(filter);
        return true;
    }

    const getUrl = () => {
        const url = new URL(window.location.href);
        if (activeFilter.length > 0) {
            url.searchParams.set(targetSelector, activeFilter.join(','));
        } else {
            url.searchParams.delete(targetSelector);
        }

        return url.toString();
    }

    const applyFilters = () => {
        for (let i = 0; i < target.childElementCount; i++) {
            const child = target.children[i];
            if (activeFilter.length > 0 && !activeFilter.includes(child.dataset[filterKey])) {
                child.classList.add("d-none");
            } else {
                child.classList.remove("d-none");
            }
        }
    }

    const saveAndApplyFilters = () => {
        window.history.replaceState(null, '', getUrl());
        applyFilters();
    }

    const currentTitle = element.innerHTML;
    element.innerHTML = `
    <details class="dropdown details-reset details-overlay d-inline-block">
        <summary class="p-2 d-inline" aria-haspopup="true">
        ${currentTitle}
        <div class="dropdown-caret"></div>
        </summary>
        <div class="SelectMenu right-0">
            <div class="SelectMenu-modal">
                <div class="SelectMenu-list">
                </div>
            </div>
        </div>
    </details>`;
    const selectList = element.querySelector(".SelectMenu-list");

    filters.forEach((filter, _idx, _) => {
        const filterButton = document.createElement("button");
        filterButton.setAttribute("role", "menuitemcheckbox");
        filterButton.classList.add("SelectMenu-item");
        filterButton.innerHTML = `
            <svg class="SelectMenu-icon SelectMenu-icon--check octicon octicon-check" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" width="16" height="16">  <path fill-rule="evenodd" clip-rule="evenodd" d="M13.78 4.22C13.9204 4.36062 13.9993 4.55125 13.9993 4.75C13.9993 4.94875 13.9204 5.13937 13.78 5.28L6.53 12.53C6.38937 12.6704 6.19875 12.7493 6 12.7493C5.80125 12.7493 5.61062 12.6704 5.47 12.53L2.22 9.28C2.08752 9.13782 2.0154 8.94978 2.01882 8.75547C2.02225 8.56117 2.10096 8.37579 2.23838 8.23837C2.37579 8.10096 2.56118 8.02225 2.75548 8.01882C2.94978 8.01539 3.13782 8.08752 3.28 8.22L6 10.94L12.72 4.22C12.8606 4.07955 13.0512 4.00066 13.25 4.00066C13.4487 4.00066 13.6394 4.07955 13.78 4.22Z"></path></svg>
            ${filter}`;
        filterButton.addEventListener("click", () => {
            const selected = toggleFilter(filter);
            if (selected) {
                filterButton.setAttribute("aria-checked", "true");
            } else {
                filterButton.removeAttribute("aria-checked");
            }
            saveAndApplyFilters();
        });
        if (activeFilter.includes(filter)) {
            filterButton.setAttribute("aria-checked", "true");
        }
        selectList.appendChild(filterButton)
    });

    applyFilters();
};

document.addEventListener('DOMContentLoaded', (_) => {
    document
        .querySelectorAll(".filter-dropdown-placeholder")
        .forEach((element, _idx, _parents) => initialiseFilter(element));
});

