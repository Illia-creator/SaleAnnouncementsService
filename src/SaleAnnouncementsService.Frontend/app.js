import axios from 'https://cdn.jsdelivr.net/npm/axios@1.3.5/+esm';


const App = {
    data() {
        return {           
            title: "Announcements:",
            announcements: [],
            criterion: "date",
            order: "desc",
            selectedCriterion: "date",
            selectedOrder: "asc",
            messageForEmpty: "Any Annoucements Were Found",
            currentPage: 1,
            itemsPerPage: 10, 
            }
    },

    methods:{
        getAll(){
            axios.get(`http://localhost:5072/api/Annoncements/announcements?Criterion=${this.criterion}&Order=${this.order}`)
            .then(response => {
                this.announcements = response.data
            })
            .catch(error => {
                console.error(error)
            })
        },

        updateOrder() {
            if(this.selectedOrder === "Ascending")
            {
                this.order = "asc"
            }
            else
            {
                this.order = "desc"
            }

            this.getAll()
        },

        updateCriterion() {
            if(this.selectedOrder === "By Date")
            {
                this.criterion = "date"
            }
            else
            {
                this.criterion = "price"
            }

            this.getAll()
        },

        selectAnnoncement(index){
            window.location.href = `announce.html?data=${encodeURIComponent(index)}`
        },    

        createAnnoncement(index){
            window.location.href = `create.html?data=${encodeURIComponent(index)}`
        },          
        
        prevPage() {
            if (this.currentPage > 1) {
              this.currentPage--;
            }
        },

          nextPage() {
            if (this.currentPage < this.totalPages) {
              this.currentPage++;
            }
          },
        },

        computed: {
            paginatedAnnouncements() {
              const startIdx = (this.currentPage - 1) * this.itemsPerPage;
              const endIdx = startIdx + this.itemsPerPage;
              return this.announcements.slice(startIdx, endIdx);
            },
            totalPages() {
              return Math.ceil(this.announcements.length / this.itemsPerPage);
            },
        },

    
    mounted(){
        this.getAll()
    }
}


Vue.createApp(App).mount('#app-div');