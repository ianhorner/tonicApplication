$(function () {
    let todoItemDataSource = new DevExpress.data.DataSource({
        store: new DevExpress.data.CustomStore({
            key: "todoItemId",
            load: function (options) {
                return $.ajax({
                    type: "GET",
                    url: '/api/todo/getall'
                }).done(function (response) {
                }).fail(function (response) {
                    console.log('Error: ' + response.responseJSON.Message);
                });
            },
            remove: function (key) {
                return $.ajax({
                    type: "DELETE",
                    url: '/api/todo/delete?id=' + key
                }).done(function (response) {
                }).fail(function (response) {
                    console.log('Error: ' + response.responseJSON.Message);
                });
            }
        })
    });

    let todoList = $('#todoList').dxList({
        dataSource: todoItemDataSource,
        displayExpr: 'text',
        allowItemDeleting: true,
    }).dxList('instance');

    $("#newItemTextBox").dxTextBox({
        placeholder: '+ New Item (press enter to submit)',
        onEnterKey: function (e) {
            let text = this.option('value');
            submitNewItem(text);
            this.reset();
        }
    });

    function submitNewItem(text) {
        let url = '/api/todo/insert?text=' + text;
        $.ajax({
            type: "POST",
            url: url
        }).done(function (response) {
            todoList.reload();
        }).fail(function (response) {
            console.log('Error: ' + response.responseJSON.Message);
        });
    }
});
