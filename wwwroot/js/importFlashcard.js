document.addEventListener("DOMContentLoaded", function () {
    const termDefiInput = document.querySelector(".term-defi-input");
    const separatorInputs = document.querySelectorAll('input[name="separator"]');
    const tagSeparatorInputs = document.querySelectorAll('input[name="tag-separator"]');
    const customTagSeparator = document.getElementById("custom-tag-separator");
    const customSeparator = document.getElementById("custom-separator");

    const previewItems = document.getElementById("preview-items");
    const nonePreviewItems = document.getElementById("none-preview-items");
    const countCard = document.getElementById("count-card");

    termDefiInput.addEventListener("keydown", function (e) {
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

        termDefiInput.placeholder = terms.join(tagSeparator);
        updatePreview();
    }

    function updatePreview() {
        const input = termDefiInput.value.trim();
        if (!input) resetPreviewItems();

        const separator = getSeparatorValue();
        const tagSeparator = getTagSeparatorValue();
        const map = convertInputToMap(input, separator, tagSeparator);

        if (input) renderPreviewItems(map);
    }

    function resetPreviewItems() {
        previewItems.innerHTML = "";
        nonePreviewItems.style.display = "block";
        countCard.textContent = `0 thẻ`;
    }

    function renderPreviewItems(map) {
        var fullHtml = "";
        var count = 1;

        for (const [key, value] of map) {
            fullHtml += createPreviewItemsHtml(key, value, count);
            count++;
        }
        previewItems.innerHTML = fullHtml;
        nonePreviewItems.style.display = "none";
        countCard.textContent = `${map.size} thẻ`;
    }

    function createPreviewItemsHtml(key, value, count) {
        const termHTML = `
                    <div class="term-item mb-3">
                        <div class="row align-items-center">
                            <div class="col-1" style="max-width: 50px;">
                                <span class="text-secondary fw-bold fs-6">${count}</span>
                            </div>
                            <div class="col-5">
                                <input type="text" class="custom-input" id="term-input" value="${key}" readonly disabled>
                                <input type="hidden" class="custom-input" name="flashcards[${count - 1}].Term" value="${key}">
                            </div>
                            <div class="col-5">
                                <input type="text" class="custom-input" id="defi-input" value="${value}" readonly disabled>
                                <input type="hidden" class="custom-input" name="flashcards[${count - 1}].Definition" value="${key}">
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
        return termHTML;
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

    termDefiInput.addEventListener("input", updatePreview);

    separatorInputs.forEach(input => input.addEventListener("change", updatePlaceholder));
    tagSeparatorInputs.forEach(input => input.addEventListener("change", updatePlaceholder));
    if (customTagSeparator) customTagSeparator.addEventListener("input", updatePlaceholder);
    if (customSeparator) customSeparator.addEventListener("input", updatePlaceholder);

    updatePlaceholder();
    updatePreview();
});
