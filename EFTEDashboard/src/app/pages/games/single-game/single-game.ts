import { NodeService } from '@/pages/service/node.service';
import { GameResultService } from '@/services/game-result-service';
import { Component, inject } from '@angular/core';
import { TreeNode } from 'primeng/api';
import { Tree } from 'primeng/tree';
import { TreeTableModule } from 'primeng/treetable';

@Component({
	selector: 'app-single-game',
	imports: [Tree, TreeTableModule],
	templateUrl: './single-game.html',
	styleUrl: './single-game.scss',
	providers: [NodeService]
})
export class SingleGame {
	treeValue: TreeNode[] = [];

	treeTableValue: TreeNode[] = [];

	selectedTreeValue: TreeNode[] = [];

	selectedTreeTableValue = {};

	cols: any[] = [];

	nodeService = inject(NodeService);
    gameService = inject(GameResultService);
	ngOnInit() {
        this.gameService.getAll().subscribe({
            next: (data) => {data.map(gr=> {
                this.treeValue.push({label: `Game ${gr.id}`, children: this.nodeService.getTreeFromGameResult(gr)});
            });
            }});
	}
}
