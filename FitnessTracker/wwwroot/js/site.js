// Scroll reveal: elements fade and rise into place as they enter the viewport.
(function () {
  var selector = [
    "main h1", ".hero", ".feature-tile", "main .card",
    "main form .mb-3", "main form .form-group", "main dl.row",
    "main .table tbody tr", "main .alert"
  ].join(",");

  var reduceMotion = window.matchMedia("(prefers-reduced-motion: reduce)").matches;
  if (reduceMotion || !("IntersectionObserver" in window)) return;

  var items = document.querySelectorAll(selector);
  var observer = new IntersectionObserver(function (entries) {
    entries.forEach(function (entry) {
      if (!entry.isIntersecting) return;
      var el = entry.target;
      el.classList.add("is-visible");
      // Hand the element back to its normal styles (hover effects, no lingering delay).
      el.addEventListener("transitionend", function done(e) {
        if (e.propertyName !== "opacity") return;
        el.removeEventListener("transitionend", done);
        el.classList.remove("reveal", "is-visible");
        el.style.removeProperty("--reveal-delay");
      });
      observer.unobserve(entry.target);
    });
  }, { threshold: 0.12, rootMargin: "0px 0px -40px 0px" });

  items.forEach(function (el) {
    // Stagger siblings so groups cascade in instead of appearing at once.
    var index = Array.prototype.indexOf.call(el.parentNode.children, el);
    el.style.setProperty("--reveal-delay", Math.min(index, 8) * 70 + "ms");
    el.classList.add("reveal");
    observer.observe(el);
  });
})();
