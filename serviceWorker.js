const staticSneakyScout = "sneaky-scout-v1"
const assets = [
  "/Sneaky-Scout/Sneaky-Scout/",
  "/Sneaky-Scout/index.html",
  "/Sneaky-Scout/resources/css/scoutingPASS.css",
  "/Sneaky-Scout/resources/js/easy.qrcode.min.js",
  "/Sneaky-Scout/resources/js/TBAInterface.js",
  "/Sneaky-Scout/resources/js/scoutingPASS.js",
  "/Sneaky-Scout/resources/fonts/robofan.ttf",
  "/Sneaky-Scout/resources/fonts/robofan.woff",
  "/Sneaky-Scout/resources/fonts/alexisv3.ttf",
  "/Sneaky-Scout/resources/fonts/alex.woff",
  "/Sneaky-Scout/2022/field_image.png",
  "/Sneaky-Scout/2022/RR_config.js",
]

self.addEventListener("install", installEvent => {
  installEvent.waitUntil(
    caches.open(staticSneakyScout).then(cache => {
      cache.addAll(assets)
    })
  )
})

self.addEventListener("fetch", fetchEvent => {
  fetchEvent.respondWith(
    caches.match(fetchEvent.request).then(res => {
      return res || fetch(fetchEvent.request)
    })
  )
})
