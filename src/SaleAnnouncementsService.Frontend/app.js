const App = {
    data() {
        return {
            counter: 0,
            title: "Counter",
            placeholderAttribute: "Enter Topic",
            inputTopic: "",
            notes: ["first"]

        }
    },

    methods:{
        inputValueHandler(event){
            this.inputTopic = event.target.value            
        },
        addNewNote(){
            this.notes.push(this.inputTopic)
            this.inputTopic = ""
        },
        deleteNote(idx){
            this.notes.splice(idx, 1)
            }
    }
}


Vue.createApp(App).mount('#app-div')