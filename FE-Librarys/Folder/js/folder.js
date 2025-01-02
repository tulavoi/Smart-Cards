let folders = [];
let isDropdownOpen = false;
let selectedFilter = 'Đã tạo';

function toggleDropdown() {
    isDropdownOpen = !isDropdownOpen;
    document.getElementById('dropdownMenu').style.display = isDropdownOpen ? 'block' : 'none';
}

function handleFilterSelect(filter) {
    selectedFilter = filter;
    document.getElementById('selectedFilter').innerText = selectedFilter;
    isDropdownOpen = false;
    document.getElementById('dropdownMenu').style.display = 'none';
    // Thêm logic lọc ở đây
}

function handleCreateClick() {
    document.getElementById('modal').style.display = 'block';
}

function closeModal() {
    document.getElementById('modal').style.display = 'none';
}

function handleSubmit(event) {
    event.preventDefault();
    const folderName = document.getElementById('folderName').value;
    if (folderName) {
        folders.push({ name: folderName });
        closeModal();
        renderFolders();
    }
}

function renderFolders() {
    const container = document.getElementById('foldersContainer');
    container.innerHTML = ''; 

    if (folders.length > 0) {
        folders.forEach((folder) => {
            const folderElement = document.createElement('div');
            folderElement.innerHTML = `
                <div class="folder-content-folderpreview">
                    <div class="folder-preview">
                        <header class="folder-preview-header">
                            <svg aria-label="folder" class="AssemblyIcon AssemblyIcon--medium" role="img">
                                <use xlink:href="#folder"></use>
                            </svg>
                            <span class="FolderPreview-cardHeaderTitle">
                                <span>${folder.name}</span>
                            </span>
                        </header>
                    </div>
                </div>
            `;
            container.appendChild(folderElement);
        });
    } else {
        const emptyState = document.querySelector('.folder-empty');
        emptyState.style.display = 'flex';
        container.appendChild(emptyState);
    }
}