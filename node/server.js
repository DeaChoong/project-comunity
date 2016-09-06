var io = require('socket.io')({
	transports: ['websocket'],
});

var index = 0;

io.attach(52273);

io.on('connection', function(socket) {
	socket.user = Array();
	
	socket.on('move', function(data) {
		
	});
	
	socket.on('join', function(data) {
		
		//socket.leave(socket.room);
		//socket.join(data.roomname);
		//socket.room = data.roomname;
	});
	
	socket.on('chat', function(data) {
		console.log(data.user + " : " + data.msg + " : " + data.data);
	});
	
	socket.on('disconnect', function() {
		
	});
});