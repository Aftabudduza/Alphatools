var currentUpdateEvent;
var addStartDate;
var addEndDate;
var globalAllDay;
var allgroup;
var AllGroupDataList;
function updateEvent(event, element) {
    if (allgroup.length >= 0) {
        //alert(event.description);
        //debugger;
        if ($(this).data("qtip")) $(this).qtip("destroy");
        if (event.HasPermission == false) {
            $(".ui-dialog-buttonset").css("display", "none");
        }
        else {
            $(".ui-dialog-buttonset").css("display", "block");
        }
        currentUpdateEvent = event;
        GetPopupContentEventCalendar(event.id);
        //$('#updatedialog').dialog('open');
        $("#eventName").val(event.title);
        $("#eventDesc").val(event.description);
        $("#eventId").val(event.id);
        $("#eventLocation").val(event.Location);
        $("#eventStart").val(moment(event.start).format('DD-MM-YYYY hh:mm A'));

        if (event.end === null) {
            $("#eventEnd").val();
        }
        else {
            $("#eventEnd").val(moment(event.end).format('DD-MM-YYYY hh:mm A'));
        }

        $("#updateGroup").empty();
        var initialvalue = false;
        if (initialvalue == false) {
            //debugger;
            var idType = 'number';
            var nameType = 'string';
            var select = document.getElementById('updateGroup');

            var keys = Object.keys(allgroup[0]);
            var idKey;
            var nameKey;
            if (keys[0].toString() == "__type") {
                idKey = typeof (parseInt(keys[0])) == idType ? keys[1] : keys[0];
                nameKey = typeof (parseInt(keys[0])) == nameType ? keys[0] : keys[1];
            } else {
                idKey = typeof (parseInt(keys[0])) == idType ? keys[0] : keys[1];
                nameKey = typeof (parseInt(keys[0])) == nameType ? keys[0] : keys[1];
            }
            $('#updateGroup').append(new Option("Select Group", "-1"));

            for (var i = 0; i < allgroup.length; i++) {
                var option = document.createElement('option');
                //var option = $("<option>");
                option.value = allgroup[i][idKey];
                option.text = allgroup[i][nameKey];
                $('#updateGroup').append(option);
            }
            initialvalue = true;
        }
        var selectedvalue = event.categoryid.toString();
        $("#updateGroup").val(selectedvalue);
    }

    return false;
}

function updateSuccess(updateResult) {
    //alert(updateResult);
    //debugger;
    if (updateResult != null) {

        var dateStart = new Date(updateResult.start);
        dateStart.toString();
        var dateEnd = new Date(updateResult.end);
        dateEnd.toString();
        currentUpdateEvent.title = updateResult.title;
        currentUpdateEvent.description = updateResult.description;
        currentUpdateEvent.start = moment(updateResult.start).format('DD-MM-YYYY hh:mm A');
        currentUpdateEvent.end = moment(updateResult.end).format('DD-MM-YYYY hh:mm A');
        currentUpdateEvent.categoryid = $("#updateGroup").val();
        currentUpdateEvent.color = updateResult.color;
        currentUpdateEvent.Location = updateResult.Location;
        $('#calendar').fullCalendar('refetchEvents');

    }
}

function deleteSuccess(deleteResult) {
    //alert(deleteResult);
    //debugger;
}

function addSuccess(addResult) {

    if (addResult != null) {
        $('#calendar').fullCalendar('renderEvent',
						{
						    title: $("#addEventName").val(),
						    start: addResult.start,
						    end: addResult.end,
						    id: addResult.id,
						    description: $("#addEventDesc").val(),
						    color: addResult.color,
						    categoryid: addResult.categoryid,
						    allDay: globalAllDay,
						    EventGroup: allgroup,
                            Location: Location
						},
						true // make the event "stick"
					);


        $('#calendar').fullCalendar('unselect');
    }
}

function UpdateTimeSuccess(updateResult) {

    //debugger;
}

function mydata(alldata) {
    //debugger;
    allgroup = alldata;
}

function selectDate(start, end, allDay, event) {
    if (allgroup.length > 0) {
        // debugger;
        $('#addDialog').dialog('open');
        $(".ui-dialog-buttonset").css("display", "block");

        $('#addEventName').val("");
        $('#addEventDesc').val("");
        $('#AddLocation').val("");
        //$("#addEventStartDate").val(moment(start).format('DD-MM-YYYY hh:mm A'));
        //$("#addEventEndDate").val(moment(end).format('DD-MM-YYYY hh:mm A'));
        //addStartDate = $("#addEventStartDate").val(moment(start).format('DD-MM-YYYY hh:mm A'));
        //addEndDate = $("#addEventEndDate").val(moment(end).format('DD-MM-YYYY hh:mm A'));
        //globalAllDay = allDay;


        $("#addEventStartDate").val(moment(start).format('MM-DD-YYYY hh:mm A'));
        $("#addEventEndDate").val(moment(end).format('MM-DD-YYYY- hh:mm A'));
        addStartDate = $("#addEventStartDate").val(moment(start).format('MM-DD-YYYY hh:mm A'));
        addEndDate = $("#addEventEndDate").val(moment(end).format('MM-DD-YYYY hh:mm A'));
        globalAllDay = allDay;



        $("#ddlGroup").empty();
        var initialvalue = false;
        if (initialvalue == false) {
            //debugger;
            var idType = 'number';
            var nameType = 'string';
            var select = document.getElementById('ddlGroup');
            var keys = Object.keys(allgroup[0]);
            var idKey;
            var nameKey;
            if (keys[0].toString() == "__type") {
                idKey = typeof (parseInt(keys[0])) == idType ? keys[1] : keys[0];
                nameKey = typeof (parseInt(keys[0])) == nameType ? keys[1] : keys[2];
            } else {
                idKey = typeof (parseInt(keys[0])) == idType ? keys[0] : keys[1];
                nameKey = typeof (parseInt(keys[0])) == nameType ? keys[0] : keys[1];
            }
            var idKeyasd = keys["Group_id"];
            var nameKeyasd = keys["Group_Name"];
            $('#ddlGroup').append(new Option("Select Group", "-1"));

            for (var i = 0; i < allgroup.length; i++) {
                var option = document.createElement('option');
                option.value = allgroup[i][idKey];
                option.text = allgroup[i][nameKey];
                $('#ddlGroup').append(option);
            }

            initialvalue = true;
        }


        $("#ddlGroup").val("-1");
    }
}

function updateEventOnDropResize(event, allDay) {
    //debugger;
    //alert("allday: " + allDay);
    var eventToUpdate = {
        id: event.id,
        start: event.start
    };


    if (event.end === null) {
        eventToUpdate.end = eventToUpdate.start;
    }
    else {
        eventToUpdate.end = event.end;
    }
    var endDate;
    if (!event.allDay) {
        endDate = new Date(eventToUpdate.end + 60 * 60000);
        endDate = endDate.toJSON();
    }
    else {
        endDate = eventToUpdate.end.toJSON();
    }

    eventToUpdate.start = eventToUpdate.start.toJSON();
    eventToUpdate.end = eventToUpdate.end.toJSON(); //endDate;
    eventToUpdate.allDay = event.allDay;

    PageMethods.UpdateEventTime(eventToUpdate, UpdateTimeSuccess);
}

function eventDropped(event, dayDelta, minuteDelta, allDay, revertFunc) {
    //debugger;
    alert('UTC: ' + (event.start).toISOString() + '\r\ndropDate: ' + moment(event.start).format('DD-MM-YYYY hh:mm A'));
    if ($(this).data("qtip")) $(this).qtip("destroy");
    updateEventOnDropResize(event);
}

function eventResized(event, dayDelta, minuteDelta, revertFunc) {
    //debugger;
    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event);
}

function checkForSpecialChars(stringToCheck) {
   // var pattern = /[^A-Za-z0-9 ]/;//A-Za-z0-9\-\_
    var pattern = /[^A-Za-z0-9\-\_]/;//A-Za-z0-9\-\_
    return pattern.test(stringToCheck);
}

function isAllDay(startDate, endDate) {
    //debugger;
    var allDay;
    var date1 = startDate.split(' ')[1];
    var date2 = endDate.split(' ')[1];
    if (date1 == "00:00" && date2 == "00:00") {
        allDay = true;
        globalAllDay = true;
    }
    else {
        allDay = false;
        globalAllDay = false;
    }

    return allDay;
}

function convertUTCDateToLocalDate(date) {
    var newDate = new Date(date.getTime() + date.getTimezoneOffset() * 60 * 1000);
    var offset = date.getTimezoneOffset() / 60;
    var hours = date.getHours();
    newDate.setHours(hours - offset);
    return newDate;
}

function qTipText(start, end, description, eventGroup, categoryid, location) {
    //debugger;
    var text;
    var slocation;
    if (end !== null)
        slocation = location;
    else
        slocation = "";

    if (end !== null)
        text = "<strong>Start:</strong> " + moment(start).format('hh:mm A') + "<br/><strong>End:</strong> " + moment(end).format('hh:mm A') + "<br/><strong>Location:</strong> " + slocation + "<br/><br/>" + description;
    else
        text = "<strong>Start:</strong> " + moment(start).format('hh:mm A') + "<br/><strong>End:</strong>" + "<br/><strong>Location:</strong> " + slocation + "<br/><br/>" + description;
    if (eventGroup !== null) {
        if (categoryid > 0) {
            $("#groupid").val(categoryid);
        }
    }

    if (allgroup.length > 0) {
        $("#updateGroup").empty();
        var initialvalue = false;
        if (initialvalue == false) {
            //debugger;
            var idType = 'number';
            var nameType = 'string';
            var select = document.getElementById('ddlGroup');
            var keys = Object.keys(allgroup[0]);
            var idKey = typeof (parseInt(keys[0])) == idType ? keys[0] : keys[1];
            var nameKey = typeof (parseInt(keys[0])) == nameType ? keys[0] : keys[1];

            $('#updateGroup').append(new Option("Select Group", "-1"));
            for (var i = 0; i < allgroup.length; i++) {
                var option = document.createElement('option');
                option.value = allgroup[i][idKey];
                option.label = allgroup[i][nameKey];
                $('#updateGroup').append(option);
            }
            initialvalue = true;
        }
    }

    return text;
}

$(document).ready(function () {
    //debugger;
    PageMethods.GetAllGroupList(true, mydata);

    // update Dialog
    //debugger;
    $('#updatedialog').dialog({
        autoOpen: false,
        width: 470,
        buttons: {
            "update": function () {
               // debugger;
                moment.createFromInputFallback = function (config) {
                    config._d = new Date(config._i);
                };
               
                var eventToUpdate = {
                    id: currentUpdateEvent.id,
                    title: $("#eventName").val(),
                    description: $("#eventDesc").val(),
                    start: $("#eventStart").val(),
                    end: $("#eventEnd").val(),
                    categoryid: $('#updateGroup').val(),
                    allDay: isAllDay($("#eventStart").val(), $("#eventEnd").val()),
                    Location: $('#eventLocation').val()
                };
                PageMethods.UpdateEvent(eventToUpdate, updateSuccess);
                $(this).dialog("close");
                $('#addEventName').empty();
                $('#addEventDesc').empty();
                $('#AddLocation').empty();

            },
            "delete": function () {
                if (confirm("Do You Really Want to Delete This Event?")) {
                    PageMethods.deleteEvent($("#eventId").val(), deleteSuccess);
                    $(this).dialog("close");
                    $('#calendar').fullCalendar('removeEvents', $("#eventId").val());
                    $('#addEventName').empty();
                    $('#addEventDesc').empty();
                    $('#AddLocation').empty();
                }
            }
        }
    });

    //add dialog
    $('#addDialog').dialog({

        autoOpen: false,
        width: 470,
        buttons: {
            "Add": function () {
               // debugger;
                var e = document.getElementById("ddlGroup");
                var groupid = e.options[e.selectedIndex].value;
                var eventToAdd = {
                    title: $("#addEventName").val(),
                    description: $("#addEventDesc").val(),
                    addStartDate: $("#addEventStartDate").val(),
                    addEndDate: $("#addEventEndDate").val(),
                    start: $("#addEventStartDate").val(),
                    end: $("#addEventEndDate").val(),
                    categoryid: $('#ddlGroup').val(),
                    allDay: isAllDay($("#addEventStartDate").val(), $("#addEventEndDate").val()),
                    Location: $("#AddLocation").val()
                };
                PageMethods.addEvent(eventToAdd, addSuccess);
                $(this).dialog("close");
                $('#addEventName').empty();
                $('#addEventDesc').empty();
                $('#AddLocation').empty();
            }
        }
    });

    //class .fc-event

    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();
    var options = {
        weekday: "long", year: "numeric", month: "short",
        day: "numeric", hour: "2-digit", minute: "2-digit"
    };

    $('#calendar').fullCalendar({
        theme: true,
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        timezone: false,
        ignoreTimezone: true,
        //defaultView: 'agendaWeek',
        defaultView: 'month',
        eventClick: updateEvent,
        selectable: true,
        selectHelper: true,
        select: selectDate,
        editable: true,

        events: "JsonResponse.ashx",
        eventDrop: eventDropped,
        eventResize: eventResized,
        eventRender: function (event, element) {
           // debugger;
            allgroup = event.EventGroup;
            var clr = event.color;
            var calssname = "testcss_" + event.categoryid;
            element.qtip({
                content: {
                    text: qTipText(event.start, event.end, event.description, event.EventGroup, event.categoryid, event.Location),
                    title: '<span style="font-size:15px"><strong>' + event.title + '</strong></span>'
                },
                position: {
                    my: 'bottom left',
                    at: 'top right'
                },
                style: { classes: 'qtip-shadow qtip-rounded calssname' },
                style: { 'calssname:background': '"' + event.color + '"!important' }
            });
        }
       
    });
});
