<script setup>
import { ref, onMounted } from 'vue'
import TodoItem from './TodoItem.vue'
const items = ref([])

onMounted(() => {
    fetch("http://localhost:5015/todo", {
        method: "GET"
    })
    .then(response => response.json())
    .then((data) => {
        console.log(data);
        items.value = data;
    })
})
</script>

<template>
  <div v-for="item in items">
    <TodoItem :name="item.name" :created="item.created" :isCompleted="item.isCompleted" />
  </div>
</template>

<style scoped>

</style>
