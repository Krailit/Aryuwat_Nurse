var headers = { headers: { "RequestVerificationToken": window.VerificationToken } };
var urlApi = window.ServerUrl + 'api/';

Vue.mixin({

    // สร้าง Method ที่ต้องการ
    methods: {

        /* ================================================================
         * API HTTP By Axios
         * ================================================================ */

        // สำหรับ Get
        httpGet: function (url, callback, errCallback) {
            axios.get(urlApi + url, headers).then(function (response) {
                // console.log(response.data);
                return callback(response.data);
            }).catch(function (error) { return errCallback(error); });
        },

        // สำหรับ Get
        httpGetJson: function (url, callback, errCallback) {
            axios.get(window.ServerUrl + url, headers).then(function (response) {
                // console.log(response.data);
                return callback(response.data);
            }).catch(function (error) { return errCallback(error); });
        },

        // สำหรับ Post
        httpPost: function (url, params, callback, errCallback) {
            axios.post(urlApi + url, params, headers).then(function (response) {
                // console.log(response.data);
                return callback(response.data);
            }).catch(function (error) { return errCallback(error); });
        },

        // สำหรับ Put
        httpPut: function (url, params, callback, errCallback) {
            axios.put(urlApi + url, params, headers).then(function (response) {
                // console.log(response.data);
                return callback(response.data);
            }).catch(function (error) { return errCallback(error); });
        },

        // สำหรับ Delete
        httpDelete: function (url, callback, errCallback) {
            axios.delete(urlApi + url, headers).then(function (response) {
                // console.log(response.data);
                return callback(response.data);
            }).catch(function (error) { return errCallback(error); });
        },

        // สำหรับ Upload File
        httpUpload: function (url, formData, callback, errCallback) {
            axios.post(urlApi + url, formData, { headers: { 'content-type': 'multipart/form-data' } }).then(function (response) {
                // console.log(response.data);
                return callback(response.data);
            }).catch(function (error) { return errCallback(error); });
        },

        /* ================================================================
         * ฟอร์ม
         * ================================================================ */

        // ตรวจสอบข้อมูล (ค่าว่าง)
        formValidation: function (formData, itemAsset, callback) {

            // สร้างตัวแปรใหม่
            var validation = true;
            var arrError = [];

            // ลูปข้อมูล (เพื่อตรวจสอบ)
            for (var i in formData) {

                // ตรวจสอบข้อมูล (ค่าว่าง) 
                if (formData[i].value === '') {
                    arrError.push(formData[i].label);
                    validation = false;
                }

                // ตรวจสอบการทำรายการสุดท้าย
                if (parseInt(i) === formData.length - 1) {

                    // ส่งข้อมูลผลการตรวจสอบ
                    return callback(validation, itemAsset, arrError.join(", "));

                }

            }

        }

    }

});