import axios from 'https://cdn.jsdelivr.net/npm/axios@1.3.5/+esm';

const announceId = {
    data() {
        return{
            title: "Announcement price",
            announcement: [],
            index: '',

        }
    },

    methods:{
        getIndex(){
            const params = new URLSearchParams(window.location.search);

            this.index = decodeURIComponent(params.get("data")) || 'No Id Recived'

            this.getAnnouncement()
        },

        getAnnouncement(){
            axios.get(`http://localhost:5072/api/Annoncements/announcement?Id=${this.index}`)
            .then(response => {
                this.announcement = response.data
                console.log(this.announcement)
            })
            .catch(error => {
                console.error(error)
            })
        },

        selectAnnoncement(){
            window.location.href = `index.html`
        },   
    },  

    mounted(){
        this.getIndex()
    }

}

Vue.createApp(announceId).mount('#announce-id');