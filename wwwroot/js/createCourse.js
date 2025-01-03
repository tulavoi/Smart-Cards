document.addEventListener("DOMContentLoaded", function () {
    const termsSection = document.getElementById('terms-section');

    // Khi nhán vào Thêm thẻ sẽ thêm 1 html terms-item
    document.querySelector('.add-card').addEventListener('click', addNewCard);

    async function addNewCard() {
        // Lấy tất cả các .term-item đang hiển thị
        const visibleTermItems = Array.from(document.querySelectorAll('.term-item')).filter(item => {
            return item.offsetParent !== null; // Kiểm tra xem phần tử có đang hiển thị không
        });

        const count = visibleTermItems.length; // Lấy count dựa trên số lượng term-item hiển thị

        const termLanguageId = document.querySelector('#btn-choose-language[data-type="term"]').value;
        const defiLanguageId = document.querySelector('#btn-choose-language[data-type="definition"]').value;

        try {
            const respone = await fetch(`/course/GetTermDefinitionPartial?count=${count}&termValue=&defiValue=
                                         &termLanguageId=${termLanguageId}&defiLanguageId=${defiLanguageId}`);

            const newCard = await respone.text();

            // Thêm card mới vào khu vực termsSection
            termsSection.insertAdjacentHTML('beforeend', newCard);

            // Gắn lại sự kiện cho nút xóa
            bindTrashButtonEvent();

            // Cập nhật lại số thứ tự cho tất cả các term-item
            const updatedTermItems = document.querySelectorAll('.term-item-count');
            updatedTermItems.forEach((item, index) => {
                item.innerText = index + 1; // Số thứ tự bắt đầu từ 1
            });
        }
        catch (error) {
            console.error('Error loading menu languages: ', error);
        }
    }

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

    // Cập nhật placeholder của termDefiTextarea dựa trên các giá trị separator và tag separator đã chọn
    function updatePlaceholder() {
        // Lấy giá trị separator và tagSeparator từ các lựa chọn
        const separator = getSeparatorValue();
        const tagSeparator = getTagSeparatorValue();

        // Tạo mảng các terms và định nghĩa của chúng, sử dụng separator giữa thuật ngữ và định nghĩa
        const terms = [
            `Từ 1${separator}Định nghĩa 1`,
            `Từ 2${separator}Định nghĩa 2`,
            `Từ 3${separator}Định nghĩa 3`
        ];

        // Cập nhật placeholder của termDefiTextarea bằng cách nối các terms với tagSeparator
        termDefiTextarea.placeholder = terms.join(tagSeparator);

        // Cập nhật lại preview sau khi placeholder được cập nhật
        updatePreview();
    }

    function getSeparatorValue() {
        // Lấy giá trị của input đã được chọn trong nhóm "separator"
        const selectedSepaator = document.querySelector('input[name="separator"]:checked').id;
        if (selectedSepaator == "custom") return customSeparator?.value || "\t"
        if (selectedSepaator == "tab") return "\t"
        return ",";
    }

    function getTagSeparatorValue() {
        // Lấy giá trị của input đã được chọn trong nhóm "tag-separator"
        const selectedTagSepaator = document.querySelector('input[name="tag-separator"]:checked').id;
        if (selectedTagSepaator == "custom-tags") return customTagSeparator?.value || "\n"
        if (selectedTagSepaator == "newline") return "\n"
        return ";";
    }

    // Cập nhật preview (xem trước) dựa trên giá trị nhập vào trong termDefiTextarea
    function updatePreview() {
        const input = termDefiTextarea.value.trim();

        if (!input) resetPreviewItems();

        const separator = getSeparatorValue();
        const tagSeparator = getTagSeparatorValue();
        const map = convertInputToMap(input, separator, tagSeparator); 

        termDefinitionMap = map; // Lưu map vào biến termDefinitionMap để sử dụng ở hàm khác

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

        // Tách input thành các phần tử, mỗi phần tử là một cặp key-value
        const pairs = input.split(tagSeparator);

        for (let i = 0; i < pairs.length; i++) {
            const part = pairs[i].split(separator); // Tách mỗi cặp thành key-value dựa trên separator
            const key = part[0]?.trim() || "";
            const value = part[1]?.trim() || "";
            map.set(key, value);
        }
        return map;
    }

    // Lắng nghe sự kiện "input" trên termDefiTextarea và gọi hàm updatePreview khi nội dung thay đổi
    termDefiTextarea.addEventListener("input", updatePreview);

    // Lặp qua tất cả các input có tên 'separator' và lắng nghe sự kiện "change" để gọi hàm updatePlaceholder khi người dùng thay đổi lựa chọn phân tách
    separatorInputs.forEach(input => input.addEventListener("change", updatePlaceholder));

    // Lặp qua tất cả các input có tên 'tag-separator' và lắng nghe sự kiện "change" để gọi hàm updatePlaceholder khi người dùng thay đổi lựa chọn phân tách thẻ
    tagSeparatorInputs.forEach(input => input.addEventListener("change", updatePlaceholder));

    // Nếu có customTagSeparator, lắng nghe sự kiện "input" để gọi hàm updatePlaceholder khi người dùng thay đổi giá trị
    if (customTagSeparator) customTagSeparator.addEventListener("input", updatePlaceholder);

    // Nếu có customSeparator, lắng nghe sự kiện "input" để gọi hàm updatePlaceholder khi người dùng thay đổi giá trị
    if (customSeparator) customSeparator.addEventListener("input", updatePlaceholder);

    updatePlaceholder();
    updatePreview();

    // Xử lý event import-btn
    document.getElementById('import-btn').addEventListener('click', () => {
        toggleContainer('.import-flashcards-container', '.create-course-container', '#f6f7fb');

        if (termDefinitionMap.size == 0 || ![...termDefinitionMap.keys()].length) return;

        // Xóa các term-item cũ trong terms-section 
        termsSection.innerHTML = '';

        renderTermsSection(termDefinitionMap);
    });

    async function renderTermsSection(map){
        var fullHtml = "";
        var count = 0;

        for (const [key, value] of map) {
            console.log(key);
            fullHtml += await createTermsSectionHtml(key, value, count);
            count++;
        }

        termsSection.innerHTML = fullHtml;
        bindTrashButtonEvent();
    }

    async function createTermsSectionHtml(key, value, count) {
        // Mã hóa key và value để tránh mất các dấu (+,...)
        const encodedKey = encodeURIComponent(key);
        const encodedValue = encodeURIComponent(value);

        // Lấy ra partialview
        const respone = await fetch(`/course/GetTermDefinitionPartial?count=${count+1}
            &termValue=${encodedKey}&defiValue=${encodedValue}`);
        const newCard = await respone.text();

        return newCard;
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

    function syncPasswordInputs() {
        const viewPasswordInput = document.getElementById('view-per-course-password-input');
        const editPasswordInput = document.getElementById('edit-per-course-password-input');

        // Lắng nghe sự kiện 'input' trên ô view
        viewPasswordInput.addEventListener('input', function () {
            editPasswordInput.value = viewPasswordInput.value;
        });

        // Lắng nghe sự kiện 'input' trên ô edit
        editPasswordInput.addEventListener('input', function () {
            viewPasswordInput.value = editPasswordInput.value;
        });
    }

    //Đồng bộ giá trị trong 2 input password
    syncPasswordInputs();

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

    // Đồng bộ giá trị trong btn-choose-language
    function syncSelectsByType(dataType) {
        termsSection.addEventListener('change', event => {
            const target = event.target;

            // Kiểm tra nếu thẻ bị thay đổi là một <select> và có data-type phù hợp
            if (target.tagName === 'SELECT' && target.getAttribute('data-type') === dataType) {
                const selectedValue = target.value; // Lấy giá trị được chọn

                // Chỉ cập nhật các select có cùng data-type
                const selects = document.querySelectorAll(`select[data-type="${dataType}"]`);
                selects.forEach(otherSelect => {
                    otherSelect.value = selectedValue;
                });
            }
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