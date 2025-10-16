---
layout: default
title: Projects
---

{% assign active-projects = site.projects | where_exp: "item", "item.end-date == nil" %}

{% assign completed-projects = site.projects | where_exp: "item", "item.end-date != nil" %}

{% include project-grid.html header="Projects" values=active-projects %}

{% include project-grid.html header="Completed Projects" values=completed-projects %}