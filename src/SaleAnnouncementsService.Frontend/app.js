import axios from 'https://cdn.jsdelivr.net/npm/axios@1.3.5/+esm';


const App = {
    data() {
        return {           
            title: "Announcements:",
            inputTopic: "",
            announcements: [],
            brHtml: "<br>"

        }
    },

    methods:{
        getAll(){
            axios.get('http://localhost:5072/api/Annoncements/announcements?PriceOrder=%22%22&PublishDateOrder=%22%22')
            .then(response => {
                this.announcements = response.data
            })
            .catch(error => {
                console.error(error)
            })
        },

        
    },
   
    watch:{
        inputTopic(value){
            console.log(value)
        }
    }
}


Vue.createApp(App).mount('#app-div')