const PROXY_CONFIG = [
  {
    context: [
      "/contents",
    ],
    target: "http://localhost:5236",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
