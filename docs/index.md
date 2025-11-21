---
layout: default
title: Home | User Empowerment Lab
---

{% include about.html %}

{% include research-area-grid.html header="Research Areas" values=site.research-areas landing=true %}

{% include paper-grid.html header="Recent Papers" values=site.publications limit=3 landing=true %}

{% comment %} TODO: Replace below with better grids {% endcomment %}
{% include card-grid.html section="projects" values=site.projects %}
{% include card-grid.html section="publications" values=site.publications %}
