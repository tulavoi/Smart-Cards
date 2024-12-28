document.addEventListener("DOMContentLoaded", function () {
    const termsSection = document.getElementById('terms-section');

    // Khi nhán vào Thêm thẻ sẽ thêm 1 html terms-item
    document.querySelector('.add-card').addEventListener('click', () => {
        const termItems = document.querySelectorAll('.term-item'); // Lấy tất cả term-item hiện có
        const newIndex = termItems.length + 1; // Lấy số thứ tự mới (bằng tổng số term-item hiện tại + 1)

        const newCard = `<div class="term-item mb-3 border-0 rounded-3 py-2 px-4">
                            <div class="row align-items-center">
                                <div class="col border-bottom">
                                    <div class="col mb-2 d-flex align-items-center justify-content-between">
                                        <span class="text-secondary fw-bold fs-6 term-item-count">@i</span>
                                        <button type="button" class="btn btn-trash ms-auto">
                                            <i class="fa-solid fa-trash"></i>
                                        </button>
                                    </div>
                                </div>
                                <div class="row my-3 term-def-input-row">
                                    <div class="col-5 pt-3">
                                        <input type="text" class="custom-input term-defi-input" name="Term">
                                        <div class="d-flex align-items-center justify-content-between mt-2">
                                            <span class="fw-bold text-secondary" style="font-size: 10px;">THUẬT NGỮ</span>
                                            @await Html.PartialAsync("ViewPartials/_MenuLanguagesPartial", new
                                                {
                                                    InputType = "term"
                                                })
                                        </div>
                                    </div>
                                    <div class="col-5 pt-3">
                                        <input type="text" class="custom-input term-defi-input" name="Definition">
                                        <div class="d-flex align-items-center justify-content-between  mt-2">
                                            <span class="fw-bold text-secondary" style="font-size: 10px;">ĐỊNH NGHĨA</span>
                                            @await Html.PartialAsync("ViewPartials/_MenuLanguagesPartial", new
                                                {
                                                    InputType = "definition"
                                                })
                                        </div>
                                    </div>
                                    <div class="col-2 text-end">
                                        <button type="button" class="btn-img btn btn-light bg-white">
                                            <i class="icon-img fa-regular fa-image"></i><br />
                                            Hình ảnh
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>`;
        termsSection.insertAdjacentHTML('beforeend', newCard);

        bindTrashButtonEvent();

        // Cập nhật lại số thứ tự cho tất cả các term-item
        const updatedTermItems = document.querySelectorAll('.term-item-count');
        updatedTermItems.forEach((item, index) => {
            item.innerText = index + 1; // Số thứ tự bắt đầu từ 1
        });
    });

    // Khi nhấn Nhập sẽ hiện lên gd nhập flashcards và ẩn gd tạo course
    document.getElementById('open-import-flashcards').addEventListener('click', () => {
        toggleContainer('.create-course-container', '.import-flashcards-container', 'white');
    });

    // Khi nhấn hủy nhập sẽ hiện lên gd tạo course và ẩn gd nhâp flashcards
    document.getElementById('cancel-import').addEventListener('click', () => {
        toggleContainer('.import-flashcards-container', '.create-course-container', '#f6f7fb');
    });

    function toggleContainer(hideSelector, showSelector, bgColor) {
        // Ẩn container hiện tại
        document.querySelector(hideSelector).style.display = 'none';

        // Hiển thị container khác
        document.querySelector(showSelector).style.display = 'block';

        // Thay đổi màu nền (nếu có)
        if (bgColor) {
            document.body.style.backgroundColor = bgColor;
        }
    }

    const termDefiTextarea = document.querySelector(".term-defi-textarea");
    const separatorInputs = document.querySelectorAll('input[name="separator"]');
    const tagSeparatorInputs = document.querySelectorAll('input[name="tag-separator"]');
    const customTagSeparator = document.getElementById("custom-tag-separator");
    const customSeparator = document.getElementById("custom-separator");

    const previewItems = document.getElementById("preview-items");
    const nonePreviewItems = document.getElementById("none-preview-items");
    const countCard = document.getElementById("count-card");

    let termDefinitionMap = new Map();

    // Cho phép bấm nút Tab (/t)
    termDefiTextarea.addEventListener("keydown", function (e) {
        if (e.key === "Tab") {
            e.preventDefault(); // Ngăn chặn hành động mặc định của phím Tab
            const start = this.selectionStart;
            const end = this.selectionEnd;

            // Chèn ký tự '\t' tại vị trí con trỏ
            this.value = this.value.substring(0, start) + "\t" + this.value.substring(end);

            // Di chuyển con trỏ sau ký tự '\t'
            this.selectionStart = this.selectionEnd = start + 1;
        }
    });

    function getSeparatorValue() {
        const selectedSepaator = document.querySelector('input[name="separator"]:checked').id;
        if (selectedSepaator == "custom") return customSeparator?.value || "\t"
        if (selectedSepaator == "tab") return "\t"
        return ",";
    }

    function getTagSeparatorValue() {
        const selectedTagSepaator = document.querySelector('input[name="tag-separator"]:checked').id;
        if (selectedTagSepaator == "custom-tags") return customTagSeparator?.value || "\n"
        if (selectedTagSepaator == "newline") return "\n"
        return ";";
    }

    function updatePlaceholder() {
        const separator = getSeparatorValue();
        const tagSeparator = getTagSeparatorValue();

        const terms = [
            `Từ 1${separator}Định nghĩa 1`,
            `Từ 2${separator}Định nghĩa 2`,
            `Từ 3${separator}Định nghĩa 3`
        ];

        termDefiTextarea.placeholder = terms.join(tagSeparator);
        updatePreview();
    }

    function updatePreview() {
        const input = termDefiTextarea.value.trim();
        if (!input) resetPreviewItems();

        const separator = getSeparatorValue();
        const tagSeparator = getTagSeparatorValue();
        const map = convertInputToMap(input, separator, tagSeparator);

        termDefinitionMap = map;

        if (input) renderPreviewItems(map);
    }

    // Reset lại preview-items nếu như không có dữ liệu trong textarea
    function resetPreviewItems() {
        previewItems.innerHTML = "";
        nonePreviewItems.style.display = "block";
        countCard.textContent = `0 thẻ`;
    }

    // Hiển thị preview-items
    function renderPreviewItems(map) {
        var fullHtml = "";
        var count = 0;

        for (const [key, value] of map) {
            fullHtml += createPreviewItemsHtml(key, value, count);
            count++;
        }
        previewItems.innerHTML = fullHtml;
        nonePreviewItems.style.display = "none";
        countCard.textContent = `${map.size} thẻ`;
    }

    // Tạo ra preview-items
    function createPreviewItemsHtml(key, value, count) {
        const tempHTML = `
                    <div class="term-item mb-3">
                        <div class="row align-items-center">
                            <div class="col-1" style="max-width: 50px;">
                                <span class="text-secondary fw-bold fs-6">${count + 1}</span>
                            </div>
                            <div class="col-5">
                                <input type="text" class="custom-input" id="term-input" value="${key}" readonly disabled>
                            </div>
                            <div class="col-5">
                                <input type="text" class="custom-input" id="defi-input" value="${value}" readonly disabled>
                            </div>
                        </div>
                        <div class="row align-items-center">
                            <div class="col-1" style="max-width: 50px;"></div>
                            <div class="col-5">
                                <span class="fw-bold text-secondary" style="font-size: 10px;">THUẬT NGỮ</span>
                            </div>
                            <div class="col-5">
                                <span class="fw-bold text-secondary" style="font-size: 10px;">ĐỊNH NGHĨA</span>
                            </div>
                        </div>
                    </div>`;
        return tempHTML;
    }

    function convertInputToMap(input, separator, tagSeparator) {
        const map = new Map();
        const pairs = input.split(tagSeparator);

        for (let i = 0; i < pairs.length; i++) {
            const part = pairs[i].split(separator);
            const key = part[0]?.trim() || "";
            const value = part[1]?.trim() || "";
            map.set(key, value);
        }
        return map;
    }

    termDefiTextarea.addEventListener("input", updatePreview);

    separatorInputs.forEach(input => input.addEventListener("change", updatePlaceholder));
    tagSeparatorInputs.forEach(input => input.addEventListener("change", updatePlaceholder));
    if (customTagSeparator) customTagSeparator.addEventListener("input", updatePlaceholder);
    if (customSeparator) customSeparator.addEventListener("input", updatePlaceholder);

    updatePlaceholder();
    updatePreview();

    document.getElementById('import-btn').addEventListener('click', () => {
        toggleContainer('.import-flashcards-container', '.create-course-container', '#f6f7fb');

        if (termDefinitionMap.size == 0 || ![...termDefinitionMap.keys()].length) return;
        console.log(termDefinitionMap);

        // Xóa các input cũ trong terms-section 
        termsSection.innerHTML = '';

        renderTermsSection(termDefinitionMap);
    });

    function renderTermsSection(map){
        var fullHtml = "";
        var count = 0;

        for (const [key, value] of map) {
            fullHtml += createTermsSectionHtml(key, value, count);
            count++;
        }

        termsSection.innerHTML = fullHtml;
        bindTrashButtonEvent();
    }

    function createTermsSectionHtml(key, value, count){
        const tempHtml = `
            <div class="term-item mb-3 border-0 rounded-3 py-2 px-4">
                <div class="row align-items-center">
                    <div class="col border-bottom">
                        <div class="col mb-2 d-flex align-items-center justify-content-between">
                            <span class="text-secondary fw-bold fs-6 term-item-count">${count + 1}</span>
                            <button type="button" class="btn btn-trash ms-auto">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>
                    </div>
                    <div class="row my-3 term-def-input-row">
                        <div class="col-5 pt-3">
                            <input type="text" class="custom-input term-defi-input" name="Term" value="${key}">
                            <div class="d-flex align-items-center justify-content-between mt-2">
                                <span class="fw-bold text-secondary" style="font-size: 10px;">THUẬT NGỮ</span>
                                @await Html.PartialAsync("ViewPartials/_MenuLanguagesPartial", new
                                    {
                                        InputType = "term"
                                    })
                            </div>
                        </div>
                        <div class="col-5 pt-3">
                            <input type="text" class="custom-input term-defi-input" name="Definition" value="${value}">
                            <div class="d-flex align-items-center justify-content-between  mt-2">
                                <span class="fw-bold text-secondary" style="font-size: 10px;">ĐỊNH NGHĨA</span>
                                @await Html.PartialAsync("ViewPartials/_MenuLanguagesPartial", new
                                    {
                                        InputType = "definition"
                                    })
                            </div>
                        </div>
                        <div class="col-2 text-end">
                            <button type="button" class="btn-img btn btn-light bg-white">
                                <i class="icon-img fa-regular fa-image"></i><br />
                                Hình ảnh
                            </button>
                        </div>
                    </div>
                </div>
            </div>`
        return tempHtml;
    }

    function updateDescription(selectId, descriptionId, passwordInputClass) {
        const select = document.getElementById(selectId);

        // Lấy option đc chọn
        const selectedOption = select.options[select.selectedIndex];

        if (selectedOption.innerText.trim() == "Người có mật khẩu") {
            document.querySelector(passwordInputClass).style.display = 'block';
        } else {
            document.querySelector(passwordInputClass).style.display = 'none';
        }

        // Lấy description từ selectId
        const des = selectedOption.getAttribute("data-description");

        // Gán description vào thẻ <p>
        const perDescription = document.getElementById(descriptionId);
        perDescription.innerText = des;
    }

    document.getElementById('view-per-select').addEventListener("change", function() {
        updateDescription('view-per-select', 'view-per-description', '#view-per-course-password-input');
    });

    document.getElementById('edit-per-select').addEventListener("change", function() {
        updateDescription('edit-per-select', 'edit-per-description', '#edit-per-course-password-input');
    })

    // Gán sẵn description vào thẻ <p> khi trang vừa tải
    window.addEventListener('DOMContentLoaded', () => {
        updateDescription('view-per-select', 'view-per-description', '#view-per-course-password-input');
        updateDescription('edit-per-select', 'edit-per-description', '#edit-per-course-password-input');
    });

    $(window).on('scroll', function () {
        var scrollTop = $(window).scrollTop();
        var header = $('#course-form-header');

        // Kiểm tra vị trí cuộn, nếu cuộn xuống thì thêm class fixed-top
        if (scrollTop > 100) {
            header.addClass('fixed-top');
        } else {
            header.removeClass('fixed-top');
        }
    });

    function syncSelectsByType(dataType) {
        const selects = document.querySelectorAll('#btn-choose-language');

        // Lắng nghe sự kiện thay đổi trên mỗi select
        selects.forEach(select => {
            select.addEventListener('change', event => {
                const selectedValue = event.target.value; // Lấy giá trị được chọn
                const dataType = event.target.getAttribute('data-type'); // Lấy data-type của select đã thay đổi

                // Chỉ cập nhật các select có cùng data-type
                selects.forEach(otherSelect => {
                    if (otherSelect.getAttribute('data-type') === dataType) {
                        otherSelect.value = selectedValue;
                    }
                });
            });
        });
    }

    syncSelectsByType("term");       
    syncSelectsByType("definition");

    // Hàm gắn sự kiện cho các nút btn-trash
    function bindTrashButtonEvent() {
        document.querySelectorAll('.btn-trash').forEach(function (btn) {
            btn.addEventListener('click', function () {
                // Tìm phần tử cha gần nhất có class "term-item"
                const termItem = btn.closest('.term-item');

                // Xóa phần tử
                termItem.remove();

                // Cập nhật lại số thứ tự
                document.querySelectorAll('.term-item').forEach(function (item, index) {
                    item.querySelector('.term-item-count').textContent = index + 1; // Cập nhật lại số thứ tự bắt đầu từ 1
                });
            });
        });
    }

    bindTrashButtonEvent();
});