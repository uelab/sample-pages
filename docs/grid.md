---
layout: default
title: Grid Test Page
---

<div class="container-fluid p-5 bg-primary text-white text-center">
  <h1>Grid Test Page</h1>
  <p>Resize this responsive page to see the effect!</p> 
</div>
<div class="container mt-5">
  <div class="row">
    <div class="col-sm-4 mt-1">
      {% include card.html %}
    </div>
    <div class="col-sm-4 mt-1">
      {% include card.html %}
    </div>
    <div class="col-sm-4 mt-1">
      {% include card.html %}
    </div>
  </div>
</div>