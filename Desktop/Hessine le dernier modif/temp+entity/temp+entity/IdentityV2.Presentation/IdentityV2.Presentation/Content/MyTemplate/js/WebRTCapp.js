function bindEvents(p) {
    
    p.on('error', function (err) {
        console.log('error',err)
    })
    p.on('signal', function (data){ 
        document.querySelector('#offer').textContent= JSON.stringify(data)
    })
    p.on('stream', function (stream) {
        let Video = document.querySelector('#receiver-video')
        Video.src = window.URL.createObjectURL(stream)
        Video.play()
    })

    document.querySelector('#incoming').addEventListener('submit', function (e) {
        e.preventDefault()

        p.signal(JSON.parse(e.target.querySelector('textarea').value))

    })
}
function startPeer(initiator) {
    navigator.getUserMedia({
        video: true,
        audio: true
    }, function (stream) {
        let p = new SimplePeer({
            initiator: initiator,
            stream: stream,
            trickle: false
        })
        bindEvents(p)
        let emitterVideo = document.querySelector('#emitter-video')
        emitterVideo.src = window.URL.createObjectURL(stream)
        emitterVideo.play()
    }, function () {
    })
}

document.querySelector('#start').addEventListener('click', function (e) {
    startPeer(true)
})

document.querySelector('#receive').addEventListener('click', function (e) {
    startPeer(false)
})

