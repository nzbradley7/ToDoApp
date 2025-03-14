<script setup>
import { ref, onMounted } from 'vue'
import TodoItem from './TodoItem.vue'
const items = ref([])
const newItem = ref()

function getList(){
  fetch("http://localhost:5015/todo", {
      method: "GET"
  })
  .then(response => response.json())
  .then((data) => {
      console.log(data);
      items.value = data;
  })
}

function completeTask(itemId, name, created, isCompleted){
    fetch("http://localhost:5015/todo/complete",
    {
      method: "PATCH",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        "Id": itemId,
        "Name": name,
        "Created": created,
        "isCompleted": isCompleted
      })
    })
      .then((response)=>{
        if(response.status != 200){throw new Error()}
        getList();
    })
    .catch((error)=>console.error(error))
}

function addItem() {
  if (newItem.value == ""){
    return;
  }
    fetch("http://localhost:5015/todo/add",
    {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        "Name": newItem.value
      })
    })
    .then((response)=>{
      if(response.status != 200){
        throw new Error("An issue arose: " + response.status);
      }
      return response.json()
    })
    .then((data)=> {
      items.value.push(data);
      console.debug(newItem.value, data);
    }).catch((error) => {
    console.error(error);
    alert("Something went wrong!")
  })
    .finally(()=> newItem.value = "")
}

onMounted(() => {
    getList();
})
</script>

<template>
  <div>
    <input v-model="newItem" placeholder="Add a new item"/>
    <button @click="addItem">Submit</button>
  </div>
  <div v-for="item in items">
    <TodoItem @mark-complete.once="completeTask" :id="item.id" :name="item.name" :created="item.created" :isCompleted="item.isCompleted" />
  </div>
</template>

<style scoped>

</style>
