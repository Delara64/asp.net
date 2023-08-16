function Validation(tag) {
    this.tag = tag;
    this.fadeTime = 3000;
    this.timeOut = 3000;

    this.ValidMessage = function (Message) {

        this.Reset();

        var newMessage = this.SuccessMessageTemplate;

        if (Message !== null)
            newMessage = newMessage.replace('##', Message);

        var MessageObject = $(newMessage);

        $('#' + this.tag).append(MessageObject);

        setTimeout(function () {
            $(MessageObject).fadeOut(this.fadeTime);
        }, this.timeOut);
    },
        this.InvalidMessage = function (Message) {

            this.Reset();

            var newMessage = this.UnsuccessMessageTemplate;

            if (Message !== null)
                newMessage = newMessage.replace('##', Message);

            var MessageObject = $(newMessage);

            $('#' + this.tag).append(MessageObject);

            setTimeout(function () {
                $(MessageObject).fadeOut(this.fadeTime);
            }, this.timeOut);
        },
        this.Reset = function () {
            $('#' + this.tag).html('');
        },
        this.SuccessMessageTemplate = '<div class="alert alert-success alert-dismissible fade in" role="alert">' +
        '<span class="glyphicon glyphicon-ok"></span>' +
        '<span> ##</span>' +
        '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
        '<span aria-hidden="true">&times;</span>' +
        '</button>' +
        '</div>'
        ,
        this.UnsuccessMessageTemplate = '<div class="alert alert-success alert-dismissible fade in" role="alert">' +
        '<span class="glyphicon glyphicon-ok"></span>' +
        '<span> ##</span>' +
        '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
        '<span aria-hidden="true">&times;</span>' +
        '</button>' +
        '</div>';
}