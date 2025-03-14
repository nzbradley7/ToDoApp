<script setup>
const props = defineProps({
    'id': String,
    'name': String,
    'created': String,
    'isCompleted': Boolean
})
const emits = defineEmits(['markComplete'])

</script>

<template>
    <div>
        <h4>
            <s v-if="isCompleted">{{ name }}</s>
            <span v-else>{{ name }}</span>
        </h4>
        <button @click="$emit('markComplete', props.id, props.name, props.created, props.isCompleted)">Mark Complete</button>
    </div>
    <div><p>{{ created }}</p></div>
</template>

<style scoped>

</style>
